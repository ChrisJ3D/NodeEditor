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

		public float radicand = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			SquareRootNode node = CreateInstance<SquareRootNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Square Root";
			
			node.CreateInput ("Radicand", "Float");
			node.CreateOutput ("Root", "Float");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			//	GUILayout.Label (label);

			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			// Inputs [0].DisplayLayout ();
			// Inputs [1].DisplayLayout();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				radicand = RTEditorGUI.FloatField (GUIContent.none, radicand);
			InputKnob (0);

			GUILayout.Space(5f);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ())
				return false;

			if (Inputs[0].connection != null)
				radicand = Inputs[0].connection.GetValue<float> ();

			Outputs[0].SetValue<float> ((float)Math.Sqrt(radicand));

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}