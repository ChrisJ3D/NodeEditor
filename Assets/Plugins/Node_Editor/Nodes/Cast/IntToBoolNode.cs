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

		public int outputValue = 0;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			IntToBoolNode node = CreateInstance<IntToBoolNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Integer to Boolean";
			
			node.CreateInput ("", "Int");
			node.CreateOutput ("Output", "Bool");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				outputValue = RTEditorGUI.IntField ("", outputValue);
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
				outputValue = Inputs[0].connection.GetValue<int> ();

			Outputs[0].SetValue<bool> (Convert.ToBoolean(outputValue));

			label = Outputs[0].GetValue(typeof(bool)).ToString();

			return true;
		}
	}
}