using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Integer to Boolean")]
	public class IntToBoolNode : Node 
	{
		public const string ID = "IntToBoolNode";
		public override string GetID { get { return ID; } }

		public override string Title { get { return "Integer to Boolean"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 50); } }

		public int outputValue = 0;

		[ValueConnectionKnob("Input", Direction.In, "Number")]
		public ValueConnectionKnob inputKnob;

		[ValueConnectionKnob("Output", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (inputKnob.connected())
				GUILayout.Label (inputKnob.name);
			else
				outputValue = RTEditorGUI.IntField ("", outputValue);

			GUILayout.Space(5f);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			outputKnob.DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();			
		}
		
		public override bool Calculate () 
		{
			outputValue = inputKnob.GetValue<Number> ();
			outputKnob.SetValue<Number> (Convert.ToBoolean(outputValue));

			return true;
		}
	}
}