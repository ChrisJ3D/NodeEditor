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
		public const string ID = "TestNode";
		public override string GetID { get { return ID; } }
		public override string Title { get { return "Test"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (200, 100); } }

		public Number value = new Number();
		public Number representedValue = new Number();

		[ValueConnectionKnob("X", Direction.In, "Number")]
		public ValueConnectionKnob xKnob;

		[ValueConnectionKnob("Y", Direction.In, "Number")]
		public ValueConnectionKnob yKnob;

		[ValueConnectionKnob("Z", Direction.In, "Number")]
		public ValueConnectionKnob zKnob;

		[ValueConnectionKnob("W", Direction.In, "Number")]
		public ValueConnectionKnob wKnob;

		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			xKnob.DisplayLayout();
			yKnob.DisplayLayout();
			zKnob.DisplayLayout();
			wKnob.DisplayLayout();

			GUILayout.EndVertical();
			GUILayout.BeginVertical();

			GUILayout.Label(representedValue.ToString());
			
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
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

			representedValue.x = xKnob.GetValue<Number>();
			representedValue.y = yKnob.GetValue<Number>();
			representedValue.z = zKnob.GetValue<Number>();
			representedValue.w = wKnob.GetValue<Number>();

			return true;
		}
	}
}