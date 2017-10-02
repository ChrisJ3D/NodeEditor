using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Constants/Boolean")]
	public class BoolNode : Node 
	{
		public const string ID = "BoolNode";
		public override string GetID { get { return ID; } }

		public Number value = new Number();
		protected string label = "";

		public override Node Create (Vector2 pos) 
		{
			BoolNode node = CreateInstance <BoolNode> ();

			node.name = "Boolean";
			node.rect = new Rect (pos.x, pos.y, 75, 50);;

			NodeOutput.Create (node, "Value", "Number");

			return node;
		}

		protected internal override void NodeGUI () 
		{			
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			value = RTEditorGUI.Toggle (value, label);

			GUILayout.EndVertical();
			GUILayout.BeginVertical();

			Outputs[0].DisplayLayout(new GUIContent(label));

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			Outputs[0].SetValue<Number> (value);
			label = value.ToBool().ToString();
			return true;
		}
	}
}