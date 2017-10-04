using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "AMHQ/Dialogue Node")]
	public class DialogueNode : Node 
	{
		public const string ID = "DialogueNode";
		public override string GetID { get { return ID; } }

		public override string Title {get { return "Dialogue"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (200, 180); } }

		public object speaker;
		public string content = "";

		[ConnectionKnob("Flow In", Direction.In, "Flow", NodeSide.Left, 10)]
		public ConnectionKnob flowInKnob;

		[ConnectionKnob("Flow Out", Direction.Out, "Flow", NodeSide.Right, 10)]
		public ConnectionKnob flowOutKnob;

		public ConnectionKnob characterKnob;
		public ConnectionKnob poseKnob;
		public ConnectionKnob expressionKnob;
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();

			for (int i = 1; i < inputKnobs.Count; i++)
				inputKnobs[i].DisplayLayout ();
			for (int i = 1; i < outputKnobs.Count; i++)
				outputKnobs[i].DisplayLayout ();

			GUILayout.EndHorizontal();

			GUILayout.TextArea(	content, 
								GUILayout.MaxHeight(115f));
			
		}
		
		public override bool Calculate () 
		{
			return true;
		}
	}

	// Connection Type only for visual purposes
	public class DialogueType : ConnectionKnobStyle 
	{
		public override string Identifier { get { return "Dialogue"; } }
		public override Color Color { get { return Color.cyan; } }
	}
}