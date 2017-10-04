using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Cast/Vector to Float")]
	public class Vector4ToFloatNode : Node 
	{
		public const string ID = "Vector4ToFloatNode";
		public override string GetID { get { return ID; } }
		public override string Title { get { return "Vector to Float"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 100); } }

		public Number x = new Number();
		public Number y = new Number();
		public Number z = new Number();
		public Number w = new Number();

		[ValueConnectionKnob("Vector", Direction.In, "Number")]
		public ValueConnectionKnob inputKnob;

		[ValueConnectionKnob("X", Direction.Out, "Number")]
		public ValueConnectionKnob xKnob;

		[ValueConnectionKnob("Y", Direction.Out, "Number")]
		public ValueConnectionKnob yKnob;

		[ValueConnectionKnob("Z", Direction.Out, "Number")]
		public ValueConnectionKnob zKnob;

		[ValueConnectionKnob("W", Direction.Out, "Number")]
		public ValueConnectionKnob wKnob;
		
		public override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (inputKnob.connected())
				inputKnob.DisplayLayout();
			else {
				x = RTEditorGUI.FloatField ("", x);
				y = RTEditorGUI.FloatField ("", y);
				z = RTEditorGUI.FloatField ("", z);
				w = RTEditorGUI.FloatField ("", w);
			}
		
			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			xKnob.DisplayLayout (new GUIContent(x));
			yKnob.DisplayLayout (new GUIContent(y));
			zKnob.DisplayLayout (new GUIContent(z));
			wKnob.DisplayLayout (new GUIContent(w));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

		}
		
		public override bool Calculate () 
		{
			if (inputKnob.connected()) {
				x = inputKnob.GetValue<Number> ().x;
				y = inputKnob.GetValue<Number> ().y;
				z = inputKnob.GetValue<Number> ().z;
				w = inputKnob.GetValue<Number> ().w;
			}

			xKnob.SetValue<Number> (x);
			yKnob.SetValue<Number> (y);
			zKnob.SetValue<Number> (z);
			wKnob.SetValue<Number> (w);

			return true;
		}
	}
}