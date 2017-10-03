using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Test/Test")]
	public class TestNode : Node 
	{
		public const string ID = "testNode";
		public override string GetID { get { return ID; } }

		[HideInInspector]
		public bool assigned = false;
		public Number value = new Number();
		int numberOfInputs;

		public override Node Create (Vector2 pos) 
		{ // This function has to be registered in Node_Editor.ContextCallback
			TestNode node = CreateInstance <TestNode> ();
			
			node.name = "Test Node";
			node.rect = new Rect (pos.x, pos.y, 150, 200);
			
			NodeInput.Create (node, "X", "Number");
			NodeInput.Create (node, "Y", "Number");
			NodeInput.Create (node, "Z", "Number");
			NodeInput.Create (node, "W", "Number");

			NodeOutput.Create (node, "X", "Number");
			NodeOutput.Create (node, "Y", "Number");
			NodeOutput.Create (node, "Z", "Number");
			NodeOutput.Create (node, "W", "Number");

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();

			for (int i = 0; i < Inputs.Count; i++) {
				if (Inputs[i] != null) {
				Inputs[i].DisplayLayout();
				InputKnob(i);
				} else {
					Inputs.RemoveAt(i);
				}
			}

			GUILayout.EndVertical();
			GUILayout.BeginVertical();

			Outputs [0].DisplayLayout (new GUIContent(value.x.ToString()));
			Outputs [1].DisplayLayout (new GUIContent(value.y.ToString()));
			Outputs [2].DisplayLayout (new GUIContent(value.z.ToString()));
			Outputs [3].DisplayLayout (new GUIContent(value.w.ToString()));

			if (GUI.Button(new Rect(70, 70, 50, 30), "+")) {
            	Debug.Log("Clicked the button with text");
				NodeInput.Create(this, "Test", "Number");
				InputKnob(Inputs.Count-1);
			}

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}
		
		public override bool Calculate () 
		{
			if (Inputs [0].connection != null) {
				value.x = Inputs[0].connection.GetValue<Number>();
			}

			if (Inputs [1].connection != null) {
				value.y = Inputs[1].connection.GetValue<Number>();
			}

			if (Inputs [2].connection != null) {
				value.z = Inputs[2].connection.GetValue<Number>();
			}

			if (Inputs [3].connection != null) {
				value.w = Inputs[3].connection.GetValue<Number>();
			}

			Outputs [0].SetValue<Number> (value.x);
			Outputs [1].SetValue<Number> (value.y);
			Outputs [2].SetValue<Number> (value.z);
			Outputs [3].SetValue<Number> (value.w);

			return true;
		}
	}
}