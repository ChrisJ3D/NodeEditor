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

		public Number value = new Number();
		protected string label_x = "";
		protected string label_y = "";
		protected string label_z = "";
		protected string label_w = "";

		public override Node Create (Vector2 pos) 
		{
			Vector4Node node = CreateInstance <Vector4Node> ();

			node.name = "Vector4";
			node.rect = new Rect (pos.x, pos.y, 200, 100);;

			node.CreateInput ("X", "Number");
			node.CreateInput ("Y", "Number");
			node.CreateInput ("Z", "Number");
			node.CreateInput ("W", "Number");

			NodeOutput.Create (node, "Value", "Number");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical();

			if (Inputs[0].connection != null) {
				Inputs[0].DisplayLayout();
			} else {
				value.x = RTEditorGUI.FloatField (GUIContent.none, value.x);
			}

			if (Inputs[1].connection != null) {
				Inputs[1].DisplayLayout();
			} else {
				value.y = RTEditorGUI.FloatField (GUIContent.none, value.y);
			}

			if (Inputs[2].connection != null) {
				Inputs[2].DisplayLayout();
			} else {
				value.z = RTEditorGUI.FloatField (GUIContent.none, value.z);
			}

			if (Inputs[3].connection != null) {
				Inputs[3].DisplayLayout();
			} else {
				value.w = RTEditorGUI.FloatField (GUIContent.none, value.w);
			}

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout (new GUIContent(value.ToString()));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
			if(GUI.changed) {
				NodeEditor.RecalculateFrom(this);
			}
		}

		public override bool Calculate () 
		{
			if (Inputs[0].connection != null) {
				value.x = Inputs[0].connection.GetValue<Number>().x;
			}

			if (Inputs[1].connection != null) {
				value.y = Inputs[1].connection.GetValue<Number>().y;
			}

			if (Inputs[2].connection != null) {
				value.z = Inputs[2].connection.GetValue<Number>().z;
			}

			if (Inputs[3].connection != null) {
				value.w = Inputs[3].connection.GetValue<Number>().w;
			}

			Outputs[0].SetValue<Number> (value);
			return true;
		}
	}
}