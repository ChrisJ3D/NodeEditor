using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Vector2")]
	public class Vector2Node : Node 
	{
		public const string ID = "Vector2Node";
		public override string GetID { get { return ID; } }

		public Vector2 value = new Vector2(0f,0f);

		public override Node Create (Vector2 pos) 
		{
			Vector2Node node = CreateInstance <Vector2Node> ();

			node.name = "Vector2";
			node.rect = new Rect (pos.x, pos.y, 200, 60);;

			NodeOutput.Create (node, "Value", "Vector2");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value.x = RTEditorGUI.FloatField (new GUIContent ("X", "The input value of type Vector2"), value.x);
			value.y = RTEditorGUI.FloatField (new GUIContent ("Y", "The input value of type Vector2"), value.y);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<Vector2> (value);
			return true;
		}
	}
}