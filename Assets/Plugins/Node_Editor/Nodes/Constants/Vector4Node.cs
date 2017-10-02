using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Vector4")]
	public class Vector4Node : Node 
	{
		public const string ID = "Vector4Node";
		public override string GetID { get { return ID; } }

		public Vector4 value = new Vector4(0f,0f,0f,0f);

		public override Node Create (Vector2 pos) 
		{
			Vector4Node node = CreateInstance <Vector4Node> ();

			node.name = "Vector4";
			node.rect = new Rect (pos.x, pos.y, 200, 90);;

			NodeOutput.Create (node, "Value", "Vector4");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			value.x = RTEditorGUI.FloatField (new GUIContent ("X", "The input value of type Vector4"), value.x);
			value.y = RTEditorGUI.FloatField (new GUIContent ("Y", "The input value of type Vector4"), value.y);
			value.z = RTEditorGUI.FloatField (new GUIContent ("Z", "The input value of type Vector4"), value.z);
			value.w = RTEditorGUI.FloatField (new GUIContent ("W", "The input value of type Vector4"), value.w);
			OutputKnob (0);

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<Vector4> (value);
			return true;
		}
	}
}