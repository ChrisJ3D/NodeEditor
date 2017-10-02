using System;
using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Math/Append")]
	public class AppendNode : Node 
	{
		public const string ID = "AppendNode";
		public override string GetID { get { return ID; } }

		public Vector2 value = new Vector2(0f,0f);
		public float valueToAppend = 0.0f;

		public override Node Create (Vector2 pos) 
		{
			AppendNode node = CreateInstance <AppendNode> ();

			node.name = "Append";
			node.rect = new Rect (pos.x, pos.y, 200, 90);

			NodeInput.Create	(node, "Input Vector", "Vector2");
			NodeInput.Create	(node, "Append", typeof(object).AssemblyQualifiedName);

			NodeOutput.Create (node, "Value", "Vector3");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();
			
			if (Inputs [0].connection != null) {
				GUILayout.Label (Inputs [0].name);
			} else {
				value.x = RTEditorGUI.FloatField (new GUIContent ("X", "The input value of type Vector2"), value.x);
				value.y = RTEditorGUI.FloatField (new GUIContent ("Y", "The input value of type Vector2"), value.y);
			}
			InputKnob(0);
			
			if (Inputs [1].connection != null) {
				GUILayout.Label (Inputs [1].name);
			} else {
				valueToAppend = RTEditorGUI.FloatField (new GUIContent ("Append", "The value to append"), valueToAppend);
			}
			InputKnob(1);

			Outputs [0].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			if (Inputs [0].connection != null) {
				value = Inputs [0].GetValue<Vector2>();
			}

			if (Inputs [1].connection != null) {
				var value1 = Inputs [1].GetValue();
				valueToAppend = (float)Convert.ChangeType(value1, typeof(float));
			}

			Vector3 appendedVector = new Vector3(value.x, value.y, valueToAppend);
			Outputs[0].SetValue<Vector3> (appendedVector);
			return true;
		}
	}
}