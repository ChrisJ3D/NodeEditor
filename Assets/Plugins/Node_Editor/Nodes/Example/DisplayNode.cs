using UnityEngine;
using System.Collections;
using NodeEditorFramework;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Test/Debug")]
	public class DisplayNode : Node 
	{
		public const string ID = "debugNode";
		public override string GetID { get { return ID; } }

		[HideInInspector]
		public bool assigned = false;
		public Number value = 0f;

		public override Node Create (Vector2 pos) 
		{ // This function has to be registered in Node_Editor.ContextCallback
			DisplayNode node = CreateInstance <DisplayNode> ();
			
			node.name = "Debug";
			node.rect = new Rect (pos.x, pos.y, 170, 150);
			
			NodeInput.Create (node, "Number", "Number");

			return node;
		}
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			Inputs [0].DisplayLayout (new GUIContent ("Number: " + (assigned? value.ToString () : ""), "The input value to display"));

			if (Inputs[0].connection != null) {
				GUILayout.Label("X: " + value.x);
				GUILayout.Label("Y: " + value.y);
				GUILayout.Label("Z: " + value.z);
				GUILayout.Label("W: " + value.w);

			}

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);

		}
		
		public override bool Calculate () 
		{
			// if (!allInputsReady ()) 
			// {
			// 	floatValue = 0;
			// 	assigned = false;
			// 	return false;
			// }

			if (Inputs[0].connection != null)
				value = Inputs[0].connection.GetValue<Number>();

			assigned = true;

			return true;
		}
	}
}