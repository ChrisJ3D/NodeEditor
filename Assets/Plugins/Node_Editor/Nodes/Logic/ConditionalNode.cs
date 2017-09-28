using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[System.Serializable]
	[Node (false, "Logic/Conditional")]
	public class ConditionalNode : Node 
	{
		public enum ConditionType { LessThan, LessThanOrEqual, Equal, GreaterThanOrEqual, Greater }
		public ConditionType method = ConditionType.Equal;

		public const string ID = "ConditionalNode";
		public override string GetID { get { return ID; } }

		public float Input1Val = 1f;
		public float Input2Val = 1f;

		public override Node Create (Vector2 pos) 
		{
			ConditionalNode node = CreateInstance <ConditionalNode> ();
			
			node.name = "Conditional";
			node.rect = new Rect (pos.x, pos.y, 200, 200);
			
			node.CreateInput ("Input 1", "Float");
			node.CreateInput ("Input 2", "Float");

			node.CreateOutput ("Result", "Bool");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				Input1Val = RTEditorGUI.FloatField (GUIContent.none, Input1Val);
			InputKnob (0);
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				Input2Val = RTEditorGUI.FloatField (GUIContent.none, Input2Val);
			InputKnob (1);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();

			Outputs [0].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

	#if UNITY_EDITOR
			method = (ConditionType)UnityEditor.EditorGUILayout.EnumPopup (new GUIContent ("Method", "The type of calculation performed on Input 1 and Input 2"), method);
	#else
			GUILayout.Label (new GUIContent ("Method: " + type.ToString (), "The type of calculation performed on Input 1 and Input 2"));
	#endif

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}

		public override bool Calculate () 
		{
			if (Inputs[0].connection != null)
				Input1Val = Inputs[0].connection.GetValue<float> ();
			if (Inputs[1].connection != null)
				Input2Val = Inputs[1].connection.GetValue<float> ();

			switch (method) 
			{
			case ConditionType.LessThan:
				if (Outputs[0] != null) {
					Outputs[0].SetValue<bool> ((Input1Val < Input2Val) ? true : false);
				}
				break;
			case ConditionType.LessThanOrEqual:
				if (Outputs[0] != null) {
					Outputs[0].SetValue<bool> ((Input1Val <= Input2Val) ? true : false);
				}
				break;
			case ConditionType.Equal:
				if (Outputs[0] != null) {
					Outputs[0].SetValue<bool> ((Input1Val == Input2Val) ? true : false);
				}
				break;
			case ConditionType.GreaterThanOrEqual:
				if (Outputs[0] != null) {
					Outputs[0].SetValue<bool> ((Input1Val >= Input2Val) ? true : false);
				}
				break;
			case ConditionType.Greater:
				if (Outputs[0] != null) {
					Outputs[0].SetValue<bool> ((Input1Val > Input2Val) ? true : false);
				}
				break;
			}

			return true;
		}
	}
}
