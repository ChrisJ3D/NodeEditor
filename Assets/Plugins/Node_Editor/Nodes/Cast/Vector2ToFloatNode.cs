using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Vector2 to Float")]
	public class Vector2ToFloatNode : Node 
	{
		public const string ID = "Vector2ToFloatNode";
		public override string GetID { get { return ID; } }

		public float x = 0f;
		public float y = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			Vector2ToFloatNode node = CreateInstance<Vector2ToFloatNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Vector2 to Float";
			
			node.CreateInput ("", "Vector2");
			node.CreateOutput ("X", "Float");
			node.CreateOutput ("Y", "Float");
			
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
			}
			

			

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			Outputs [1].DisplayLayout ();
			
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
				x = Inputs[0].connection.GetValue<Vector2> ().x;
				y = Inputs[0].connection.GetValue<Vector2> ().y;
			}

			Outputs[0].SetValue<float> (x);
			Outputs[1].SetValue<float> (y);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}