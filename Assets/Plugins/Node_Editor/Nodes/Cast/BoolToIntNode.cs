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

		public bool outputValue = false;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			BoolToIntNode node = CreateInstance<BoolToIntNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Boolean to Integer";
			
			node.CreateInput ("", "Bool");
			node.CreateOutput ("Output", "Int");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				outputValue = RTEditorGUI.Toggle (outputValue, "");
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
				outputValue = Inputs[0].connection.GetValue<bool> ();

			Outputs[0].SetValue<int> (Convert.ToInt32(outputValue));

			label = Outputs[0].GetValue(typeof(int)).ToString();

			return true;
		}
	}
}