using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Float to Vector3")]
	public class FloatToVector3Node : Node 
	{
		public const string ID = "FloatToVector3Node";
		public override string GetID { get { return ID; } }

		public float outputValue = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			FloatToVector3Node node = CreateInstance<FloatToVector3Node> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Float to Vector3";
			
			node.CreateInput ("", "Float");
			node.CreateOutput ("Output", "Vector3");
			
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

			Outputs[0].SetValue<Vector3> (new Vector3(outputValue, outputValue, outputValue));

			label = Outputs[0].GetValue(typeof(Vector3)).ToString();

			return true;
		}
	}
}