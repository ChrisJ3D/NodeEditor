using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Variables/String")]
	public class StringNode : Node 
	{
		public const string ID = "StringNode";
		public override string GetID { get { return ID; } }

		public string value = "";

		public override Node Create (Vector2 pos) 
		{
			StringNode node = CreateInstance <StringNode> ();

			node.name = "String";
			node.rect = new Rect (pos.x, pos.y, 200, 50);;

			NodeOutput.Create (node, "Value", "String");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value = RTEditorGUI.TextField (new GUIContent(""), value, null);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<string> (value);
			return true;
		}
	}
}