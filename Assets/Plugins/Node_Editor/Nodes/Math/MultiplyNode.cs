using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Multiply")]
	public class MultiplyNode : Node 
	{
		public const string ID = "multiplyNode";
		public override string GetID { get { return ID; } }

		public override string Title { get { return "Multiply"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 70); } }

		[ValueConnectionKnob("Factor 1", Direction.In, "Number")]
		public ValueConnectionKnob aKnob;
		[ValueConnectionKnob("Factor 2", Direction.In, "Number")]
		public ValueConnectionKnob bKnob;
		[ValueConnectionKnob("Product", Direction.Out, "Number")]
		public ValueConnectionKnob outputKnob;

		public Number factor1 = 0f;
		public Number factor2 = 0f;
		protected string label = "";
		
		public override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			// Inputs [0].DisplayLayout ();
			// Inputs [1].DisplayLayout();

			if (aKnob.connected()) {
				GUILayout.Label (aKnob.name);
				aKnob.DisplayLayout();
			}
			else
				factor1 = RTEditorGUI.FloatField (GUIContent.none, factor1);

			GUILayout.Space(5f);
			
			// --
			if (bKnob.connected()) {
				GUILayout.Label (bKnob.name);
				bKnob.DisplayLayout();
			}
			else
				factor2 = RTEditorGUI.FloatField (GUIContent.none, factor2);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			outputKnob.DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (aKnob.connected())
				factor1 = aKnob.GetValue<Number> ();
			if (bKnob.connected())
				factor2 = bKnob.GetValue<Number> ();

			outputKnob.SetValue<Number> (factor1 * factor2);

			return true;
		}
	}
}