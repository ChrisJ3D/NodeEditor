using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Vector3 to Float")]
	public class Vector3ToFloatNode : Node 
	{
		public const string ID = "Vector3ToFloatNode";
		public override string GetID { get { return ID; } }

		public float x = 0f;
		public float y = 0f;
		public float z = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			Vector3ToFloatNode node = CreateInstance<Vector3ToFloatNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 80);
			node.name = "Vector3 to Float";
			
			node.CreateInput ("", "Vector3");
			node.CreateOutput ("X", "Float");
			node.CreateOutput ("Y", "Float");
			node.CreateOutput ("Z", "Float");
			
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
			}
		
			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			Outputs [1].DisplayLayout ();
			Outputs [2].DisplayLayout ();
			
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
				x = Inputs[0].connection.GetValue<Vector3> ().x;
				y = Inputs[0].connection.GetValue<Vector3> ().y;
				z = Inputs[0].connection.GetValue<Vector3> ().z;
			}

			Outputs[0].SetValue<float> (x);
			Outputs[1].SetValue<float> (y);
			Outputs[2].SetValue<float> (z);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}