using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Variables/Bool")]
	public class BoolNode : Node 
	{
		public const string ID = "BoolNode";
		public override string GetID { get { return ID; } }

		public bool value = false;

		public override Node Create (Vector2 pos) 
		{
			BoolNode node = CreateInstance <BoolNode> ();

			node.name = "Boolean";
			node.rect = new Rect (pos.x, pos.y, 200, 50);;

			NodeOutput.Create (node, "Value", "Bool");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value = RTEditorGUI.Toggle (value, "");
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<bool> (value);
			return true;
		}
	}
}