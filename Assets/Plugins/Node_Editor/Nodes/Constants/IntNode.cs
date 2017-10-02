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

		public Number value = new Number();

		public override Node Create (Vector2 pos) 
		{
			IntNode node = CreateInstance <IntNode> ();

			node.name = "Integer";
			node.rect = new Rect (pos.x, pos.y, 200, 50);;

			node.CreateInput("Value", "Number");
			NodeOutput.Create (node, "Value", "Number");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();

			if (Inputs[0].connection != null) {
				Inputs[0].DisplayLayout();
			} else {
				value = RTEditorGUI.IntField (value);
			}

			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			
			Outputs[0].DisplayLayout(new GUIContent(value));

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			if (Inputs[0].connection != null) {
				value = Inputs[0].connection.GetValue<Number>().ToInt32();
			}

			Outputs[0].SetValue<Number> (value);
			return true;
		}
	}
}