using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Float to Vector2")]
	public class FloatToVector2Node : Node 
	{
		public const string ID = "FloatToVector2Node";
		public override string GetID { get { return ID; } }

		public float outputValue = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			FloatToVector2Node node = CreateInstance<FloatToVector2Node> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Float to Vector2";
			
			node.CreateInput ("", "Float");
			node.CreateOutput ("Output", "Vector2");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				outputValue = RTEditorGUI.FloatField ("", outputValue);
			InputKnob (0);

			GUILayout.Space(5f);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
			
		}
		
		public override bool Calculate () 
		{
			// if (!allInputsReady ())
			// 	return false;

			if (Inputs[0].connection != null)
				outputValue = Inputs[0].connection.GetValue<int> ();

			Outputs[0].SetValue<Vector2> (new Vector2(outputValue, outputValue));

			label = Outputs[0].GetValue(typeof(Vector2)).ToString();

			return true;
		}
	}
}