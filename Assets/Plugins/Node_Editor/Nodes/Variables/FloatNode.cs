using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Variables/Float")]
	public class FloatNode : Node 
	{
		public const string ID = "FloatNode";
		public override string GetID { get { return ID; } }

		public float value = 1f;

		public override Node Create (Vector2 pos) 
		{
			FloatNode node = CreateInstance <FloatNode> ();

			node.name = "Float";
			node.rect = new Rect (pos.x, pos.y, 200, 50);;

			NodeOutput.Create (node, "Value", "Float");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value = RTEditorGUI.FloatField (new GUIContent ("Value", "The input value of type float"), value);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<float> (value);
			return true;
		}
	}
}