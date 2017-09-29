using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Float to Vector4")]
	public class FloatToVector4Node : Node 
	{
		public const string ID = "FloatToVector4Node";
		public override string GetID { get { return ID; } }

		public float outputValue = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			FloatToVector4Node node = CreateInstance<FloatToVector4Node> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Float to Vector4";
			
			node.CreateInput ("", "Float");
			node.CreateOutput ("Output", "Vector4");
			
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
				outputValue = Inputs[0].connection.GetValue<float> ();

			Outputs[0].SetValue<Vector4> (new Vector4(outputValue, outputValue, outputValue, outputValue));

			label = Outputs[0].GetValue(typeof(Vector4)).ToString();

			return true;
		}
	}
}