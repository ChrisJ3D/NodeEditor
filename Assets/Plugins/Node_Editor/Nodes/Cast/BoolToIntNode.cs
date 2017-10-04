using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Boolean to Integer")]
	public class BoolToIntNode : Node 
	{
		public const string ID = "BoolToIntNode";
		public override string GetID { get { return ID; } }
		public override string Title { get { return "Boolean to Integer"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 50); } }

		[ValueConnectionKnob("Input", Direction.In, "Number")]
		public ValueConnectionKnob inputKnob;		

		[ValueConnectionKnob("Output", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;

		public bool outputValue = false;
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			inputKnob.DisplayLayout();

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
			outputKnob.SetValue<Number> (Convert.ToInt32(outputValue));

			return true;
		}
	}
}