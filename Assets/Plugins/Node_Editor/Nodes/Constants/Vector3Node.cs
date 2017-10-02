using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Vector3")]
	public class Vector3Node : Node 
	{
		public const string ID = "Vector3Node";
		public override string GetID { get { return ID; } }

		public Number value = new Vector3(0f,0f,0f);

		public override Node Create (Vector2 pos) 
		{
			Vector3Node node = CreateInstance <Vector3Node> ();

			node.name = "Vector3";
			node.rect = new Rect (pos.x, pos.y, 200, 80);;

			NodeOutput.Create (node, "Value", "Number");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value.x = RTEditorGUI.FloatField (new GUIContent ("X", "The input value of type Vector3"), value.x);
			value.y = RTEditorGUI.FloatField (new GUIContent ("Y", "The input value of type Vector3"), value.y);
			value.z = RTEditorGUI.FloatField (new GUIContent ("Z", "The input value of type Vector3"), value.z);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<Number> (value);
			return true;
		}
	}
}