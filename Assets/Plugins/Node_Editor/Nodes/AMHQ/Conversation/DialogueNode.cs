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

		public object speaker;
		public string content = "";
		
		public override Node Create (Vector2 pos) 
		{
			DialogueNode node = CreateInstance<DialogueNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 200, 180);
			node.name = "Dialogue";

			// Flow connections
			node.CreateInput ("Flow", "Flow", NodeSide.Left, 10);
			node.CreateOutput ("Flow", "Flow", NodeSide.Right, 10);

			// Some Connections
			node.CreateInput ("Character", "Number");
			node.CreateInput ("Pose", "Number");
			node.CreateInput ("Expression", "Number");
			

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			// Display Connections
			// Start counter at 1 to ignore flow connections
			for (int inCnt = 1; inCnt < Inputs.Count; inCnt++)
				Inputs[inCnt].DisplayLayout ();
			for (int outCnt = 1; outCnt < Outputs.Count; outCnt++)
				Outputs[outCnt].DisplayLayout ();

			GUILayout.TextArea(	content, 
								GUILayout.MaxHeight(115f));
		}
		
		public override bool Calculate () 
		{
			return true;
		}
	}

	// Connection Type only for visual purposes
	public class DialogueType : IConnectionTypeDeclaration 
	{
		public string Identifier { get { return "Dialogue"; } }
		public Type Type { get { return typeof(void); } }
		public Color Color { get { return Color.cyan; } }
		public string InKnobTex { get { return "Textures/In_Knob.png"; } }
		public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
	}
}