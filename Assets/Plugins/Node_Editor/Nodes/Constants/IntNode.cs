using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Integer")]
	public class IntNode : Node 
	{
		public const string ID = "IntNode";
		public override string GetID { get { return ID; } }

		public int value = 0;

		public override Node Create (Vector2 pos) 
		{
			IntNode node = CreateInstance <IntNode> ();

			node.name = "Integer";
			node.rect = new Rect (pos.x, pos.y, 200, 50);;

			NodeOutput.Create (node, "Value", "Int");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value = RTEditorGUI.IntField (new GUIContent ("Value", "The input value of type int"), value);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<int> (value);
			return true;
		}
	}
}