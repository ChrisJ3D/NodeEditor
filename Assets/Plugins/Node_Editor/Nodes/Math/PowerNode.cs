using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Power")]
	public class PowerNode : Node 
	{
		public const string ID = "powerNode";
		public override string GetID { get { return ID; } }

		public Number Base = new Number();
		public Number exponent = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			PowerNode node = CreateInstance<PowerNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Power";
			
			node.CreateInput ("Base", "Number");
			node.CreateInput ("Exponent", "Number");
			node.CreateOutput ("Power", "Number");
			
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
				Inputs[0].DisplayLayout ();
			else
				Base = RTEditorGUI.FloatField (GUIContent.none, Base);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				Inputs[1].DisplayLayout ();
			else
				exponent = RTEditorGUI.FloatField (GUIContent.none, exponent);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout (new GUIContent(label));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed) {
					NodeEditor.RecalculateFrom (this);
			}
			
		}
		
		public override bool Calculate () 
		{

			if (Inputs[0].connection != null)
				Base = Inputs[0].connection.GetValue<Number> ();
				
			if (Inputs[1].connection != null)
				exponent = Inputs[1].connection.GetValue<Number> ();

			Outputs[0].SetValue<Number> (Math.Pow(Base, exponent));

			label = Outputs[0].GetValue<Number> ().ToString();

			return true;
		}
	}
}