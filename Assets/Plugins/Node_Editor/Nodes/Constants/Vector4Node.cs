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
		public override string Title { get { return "Vector"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (200, 100); } }

		public Number value = new Number();
		protected string label_x = "";
		protected string label_y = "";
		protected string label_z = "";
		protected string label_w = "";

		[ValueConnectionKnob("X", Direction.In, "Number")]
		public ValueConnectionKnob xKnob;

		[ValueConnectionKnob("Y", Direction.In, "Number")]
		public ValueConnectionKnob yKnob;

		[ValueConnectionKnob("Z", Direction.In, "Number")]
		public ValueConnectionKnob zKnob;

		[ValueConnectionKnob("W", Direction.In, "Number")]
		public ValueConnectionKnob wKnob;

		[ValueConnectionKnob("Vector", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;

		public override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical();

			if (xKnob.connected()) {
				xKnob.DisplayLayout();
			} else {
				value.x = RTEditorGUI.FloatField (GUIContent.none, value.x);
			}

			if (yKnob.connected()) {
				yKnob.DisplayLayout();
			} else {
				value.y = RTEditorGUI.FloatField (GUIContent.none, value.y);
			}

			if (zKnob.connected()) {
				zKnob.DisplayLayout();
			} else {
				value.z = RTEditorGUI.FloatField (GUIContent.none, value.z);
			}

			if (wKnob.connected()) {
				wKnob.DisplayLayout();
			} else {
				value.w = RTEditorGUI.FloatField (GUIContent.none, value.w);
			}

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			outputKnob.DisplayLayout (new GUIContent(value.ToString()));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
		}

		public override bool Calculate () 
		{
			if (xKnob.connected()) {
				value.x = xKnob.GetValue<Number>().x;
			}

			if (yKnob.connected()) {
				value.y = yKnob.GetValue<Number>().y;
			}

			if (zKnob.connected()) {
				value.z = zKnob.GetValue<Number>().z;
			}

			if (wKnob.connected()) {
				value.w = wKnob.GetValue<Number>().w;
			}

			outputKnob.SetValue<Number> (value);
			return true;
		}
	}
}