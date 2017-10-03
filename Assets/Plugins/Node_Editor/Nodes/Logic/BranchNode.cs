using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "AMHQ/Logic/Branch")]
	public class BranchNode : Node 
	{
		public const string ID = "BranchNode";
		public override string GetID { get { return ID; } }

		public object speaker;
		public string content = "";
		
		public override Node Create (Vector2 pos) 
		{
			BranchNode node = CreateInstance<BranchNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Branch";

			// Flow connections
			node.CreateInput ("Flow", "Flow");
			node.CreateInput ("Condition", "Bool");
			node.CreateOutput ("True", "Flow");
			node.CreateOutput ("False", "Flow");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			// Display Connections
			// Start counter at 1 to ignore flow connections
			for (int inCnt = 1; inCnt < Inputs.Count; inCnt++)
				Inputs[inCnt].DisplayLayout ();

			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			for (int outCnt = 1; outCnt < Outputs.Count; outCnt++)
				Inputs[outCnt].DisplayLayout ();

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

		}
		
		public override bool Calculate () 
		{
			return true;
		}
	}
}