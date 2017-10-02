using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Float")]
	public class FloatNode : Node 
	{
		public const string ID = "FloatNode";
		public override string GetID { get { return ID; } }

		public Number value = new Number();

		public override Node Create (Vector2 pos) 
		{
			FloatNode node = CreateInstance <FloatNode> ();

			node.name = "Float";
			node.rect = new Rect (pos.x, pos.y, 200, 50);

			node.CreateInput("Value", "Number");
			node.CreateOutput ("Value", "Number");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();

			GUILayout.Space(5f);

			if (Inputs[0].connection != null) {
				Inputs[0].DisplayLayout();
			} else {
				value = RTEditorGUI.FloatField (value);
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
				value = Inputs[0].GetValue<Number>();
			}
			
			Outputs[0].SetValue<Number> (value);
			return true;
		}
	}
}