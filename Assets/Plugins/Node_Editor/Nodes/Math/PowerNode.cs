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

		public float Base = 0f;
		public float exponent = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			PowerNode node = CreateInstance<PowerNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Power";
			
			node.CreateInput ("Base", "Float");
			node.CreateInput ("Exponent", "Float");
			node.CreateOutput ("Power", "Float");
			
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
				Base = RTEditorGUI.FloatField (GUIContent.none, Base);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				exponent = RTEditorGUI.FloatField (GUIContent.none, exponent);
			InputKnob (1);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed) {
					NodeEditor.RecalculateFrom (this);
			}
			
		}
		
		public override bool Calculate () 
		{
			// if (!allInputsReady ())
			// 	return false;

			if (Inputs[0].connection != null)
				Base = Inputs[0].connection.GetValue<float> ();
			if (Inputs[1].connection != null)
				exponent = Inputs[1].connection.GetValue<float> ();

			Outputs[0].SetValue<float> ((float)Math.Pow(Base, exponent));

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}