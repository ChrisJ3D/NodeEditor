﻿using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Subtract")]
	public class SubtractNode : Node 
	{
		public const string ID = "subtractNode";
		public override string GetID { get { return ID; } }

		public float minuend = 0f;
		public float subtrahend = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			SubtractNode node = CreateInstance<SubtractNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Subtract";
			
			node.CreateInput ("Minuend", "Float");
			node.CreateInput ("Subtrahend", "Float");
			node.CreateOutput ("Difference", "Float");
			
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
				minuend = RTEditorGUI.FloatField (GUIContent.none, minuend);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				subtrahend = RTEditorGUI.FloatField (GUIContent.none, subtrahend);
			InputKnob (1);

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
				minuend = Inputs[0].connection.GetValue<float> ();
			if (Inputs[1].connection != null)
				subtrahend = Inputs[1].connection.GetValue<float> ();

			Outputs[0].SetValue<float> (minuend - subtrahend);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}