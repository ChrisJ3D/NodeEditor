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
		public float floatValue = 0f;
		public bool boolValue = false;
		public int intValue = 0;
		public string stringValue = "";
		public Vector2 vector2Value = new Vector2(0,0);
		public Vector3 vector3Value = new Vector3(0,0,0);
		public Vector4 vector4Value = new Vector4(0,0,0,0);

		public override Node Create (Vector2 pos) 
		{ // This function has to be registered in Node_Editor.ContextCallback
			DisplayNode node = CreateInstance <DisplayNode> ();
			
			node.name = "Debug";
			node.rect = new Rect (pos.x, pos.y, 170, 150);
			
			NodeInput.Create (node, "Float", "Float");
			NodeInput.Create (node, "Boolean", "Bool");
			NodeInput.Create (node, "Integer", "Int");
			NodeInput.Create (node, "String", "String");
			NodeInput.Create (node, "Vector2", "Vector2");
			NodeInput.Create (node, "Vector3", "Vector3");
			NodeInput.Create (node, "Vector4", "Vector4");

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			Inputs [0].DisplayLayout (new GUIContent ("Float: " + (assigned? floatValue.ToString () : ""), "The input value to display"));
			Inputs [1].DisplayLayout (new GUIContent ("Boolean: " + (assigned? boolValue.ToString () : ""), "The input value to display"));
			Inputs [2].DisplayLayout (new GUIContent ("Integer: " + (assigned? intValue.ToString () : ""), "The input value to display"));
			Inputs [3].DisplayLayout (new GUIContent ("String: " + (assigned? stringValue.ToString () : ""), "The input value to display"));
			Inputs [4].DisplayLayout (new GUIContent ("Vector2: " + (assigned? vector2Value.ToString () : ""), "The input value to display"));
			Inputs [5].DisplayLayout (new GUIContent ("Vector3: " + (assigned? vector3Value.ToString () : ""), "The input value to display"));
			Inputs [6].DisplayLayout (new GUIContent ("Vector4: " + (assigned? vector4Value.ToString () : ""), "The input value to display"));

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
			floatValue = Inputs[0].connection.GetValue<float>();

			if (Inputs[1].connection != null)
			boolValue = Inputs[1].connection.GetValue<bool>();

			if (Inputs[2].connection != null)
			intValue = Inputs[2].connection.GetValue<int>();

			if (Inputs[3].connection != null)
			stringValue = Inputs[3].connection.GetValue<string>();

			if (Inputs[4].connection != null)
			vector2Value = Inputs[4].connection.GetValue<Vector2>();

			if (Inputs[5].connection != null)
			vector3Value = Inputs[5].connection.GetValue<Vector3>();

			if (Inputs[6].connection != null)
			vector4Value = Inputs[6].connection.GetValue<Vector4>();

			assigned = true;

			return true;
		}
	}
}