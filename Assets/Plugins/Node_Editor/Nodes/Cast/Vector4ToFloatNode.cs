using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Vector4 to Float")]
	public class Vector4ToFloatNode : Node 
	{
		public const string ID = "Vector4ToFloatNode";
		public override string GetID { get { return ID; } }

		public float x = 0f;
		public float y = 0f;
		public float z = 0f;
		public float w = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			Vector4ToFloatNode node = CreateInstance<Vector4ToFloatNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 95);
			node.name = "Vector4 to Float";
			
			node.CreateInput ("", "Vector4");
			node.CreateOutput ("X", "Float");
			node.CreateOutput ("Y", "Float");
			node.CreateOutput ("Z", "Float");
			node.CreateOutput ("W", "Float");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			GUILayout.Space(5f);
			InputKnob (0);

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else {
				x = RTEditorGUI.FloatField ("", x);
				y = RTEditorGUI.FloatField ("", y);
				z = RTEditorGUI.FloatField ("", z);
				w = RTEditorGUI.FloatField ("", w);
			}
		
			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			Outputs [1].DisplayLayout ();
			Outputs [2].DisplayLayout ();
			Outputs [3].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
			
		}
		
		public override bool Calculate () 
		{
			// if (!allInputsReady ())
			// 	return false;

			if (Inputs[0].connection != null) {
				x = Inputs[0].connection.GetValue<Vector4> ().x;
				y = Inputs[0].connection.GetValue<Vector4> ().y;
				z = Inputs[0].connection.GetValue<Vector4> ().z;
				w = Inputs[0].connection.GetValue<Vector4> ().w;
			}

			Outputs[0].SetValue<float> (x);
			Outputs[1].SetValue<float> (y);
			Outputs[2].SetValue<float> (z);
			Outputs[3].SetValue<float> (w);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}