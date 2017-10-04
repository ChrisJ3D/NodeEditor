﻿using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Float")]
	public class FloatNode : Node 
	{
		public const string ID = "FloatNode";
		public override string GetID { get { return ID; } }

		public override string Title { get { return "Float"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (200, 50); } }

		[ValueConnectionKnob("Input", Direction.In, "Number")]
		public ValueConnectionKnob inputKnob;
		[ValueConnectionKnob("Output", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;		

		public Number value = new Number();

		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();

			GUILayout.Space(5f);

			if (inputKnob.connected()) {
				inputKnob.DisplayLayout();
			} else {
				value = RTEditorGUI.FloatField (value);
			}
			
			GUILayout.EndVertical();
			GUILayout.BeginVertical();

			outputKnob.DisplayLayout(new GUIContent(value));

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}

		public override bool Calculate () 
		{
			if (inputKnob.connected()) {
				value = inputKnob.GetValue<Number>();
			}
			
			outputKnob.SetValue<Number> (value);
			return true;
		}
	}
}