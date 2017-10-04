using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Subtract")]
	public class SubtractNode : Node 
	{
		public const string ID = "subtractNode";
		public override string GetID { get { return ID; } }

		public override string Title { get { return "Subtract"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 70); } }

		[ValueConnectionKnob("Minuend", Direction.In, "Number")]
		public ValueConnectionKnob aKnob;
		[ValueConnectionKnob("Subtrahend", Direction.In, "Number")]
		public ValueConnectionKnob bKnob;
		[ValueConnectionKnob("Difference", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;

		public Number minuend = 0f;
		public Number subtrahend = 0f;
		protected string label = "";
		
		public override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (aKnob.connected()) {
				GUILayout.Label (aKnob.name);
				aKnob.DisplayLayout();
			}
			else
				minuend = RTEditorGUI.FloatField (GUIContent.none, minuend);

			GUILayout.Space(5f);
			
			// --
			if (bKnob.connected()) {
				GUILayout.Label (bKnob.name);
				bKnob.DisplayLayout();
			}
			else
				subtrahend = RTEditorGUI.FloatField (GUIContent.none, subtrahend);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			outputKnob.DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (aKnob.connected())
				minuend = aKnob.GetValue<Number> ();
			if (bKnob.connected())
				subtrahend = bKnob.GetValue<Number> ();

			outputKnob.SetValue<Number> (minuend - subtrahend);

			label = outputKnob.GetValue(typeof(Number)).ToString();

			return true;
		}
	}
}