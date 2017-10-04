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
		public override string Title { get { return "Branch"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 70); } }

		[ConnectionKnob("Flow In", Direction.In, "Flow", NodeSide.Left, 10)]
		public ConnectionKnob flowIn;

		[ConnectionKnob("Flow In", Direction.In, "Number")]
		public ConnectionKnob conditionKnob;

		[ConnectionKnob("Flow Out", Direction.Out, "Flow")]
		public ConnectionKnob trueKnob;

		[ConnectionKnob("Flow Out", Direction.Out, "Flow")]
		public ConnectionKnob falseKnob;		

		public object speaker;
		public string content = "";
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();

			flowIn.DisplayLayout();
			conditionKnob.DisplayLayout();

			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			
			trueKnob.DisplayLayout();
			falseKnob.DisplayLayout();

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}
		
		public override bool Calculate () 
		{
			return true;
		}
	}
}