using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Square Root")]
	public class SquareRootNode : Node 
	{
		public const string ID = "SquareRootNode";
		public override string GetID { get { return ID; } }

		public Number radicand = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			SquareRootNode node = CreateInstance<SquareRootNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Square Root";
			
			node.CreateInput ("Radicand", "Number");
			node.CreateOutput ("Root", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				Inputs[0].DisplayLayout();
			else
				radicand = RTEditorGUI.FloatField (GUIContent.none, radicand);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();

			Outputs [0].DisplayLayout (new GUIContent(label));

			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if(GUI.changed) {
				NodeEditor.RecalculateFrom(this);
			}
		}
		
		public override bool Calculate () 
		{
			if (Inputs[0].connection != null) {
				radicand = Inputs[0].connection.GetValue<Number> ();
			}

			Outputs[0].SetValue<Number> (Math.Sqrt(radicand));

			label = Outputs[0].GetValue<Number> ();

			return true;
		}
	}
}