using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Effects/SDF/Box")]
	public class BoxNode : Node 
	{
		public const string ID = "BoxNode";
		public override string GetID { get { return ID; } }
		public override string Title { get { return "Box"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (150, 150); } }

		public Number width = new Number();
		public Number height = new Number();
		public Number depth = new Number();
		protected string label = "";

		[ValueConnectionKnob("Width", Direction.In, "Number")]
		public ValueConnectionKnob widthKnob;

		[ValueConnectionKnob("Height", Direction.In, "Number")]
		public ValueConnectionKnob heightKnob;

		[ValueConnectionKnob("Depth", Direction.In, "Number")]
		public ValueConnectionKnob depthKnob;

		[ValueConnectionKnob("Position", Direction.Out, "Number")]
		public ValueConnectionKnob positionKnob;
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			inputKnobs[0].DisplayLayout ();
			inputKnobs[1].DisplayLayout ();
			inputKnobs[2].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			outputKnobs [0].DisplayLayout (new GUIContent(label));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();			
		}
		
		public override bool Calculate () 
		{


			width = widthKnob.GetValue<Number>();
			
			height = heightKnob.GetValue<Number> ();

			depth = depthKnob.GetValue<Number> ();

			// Outputs[0].SetValue<Number> (SDF_Box);

			label = positionKnob.GetValue<Number> ().ToString();

			return true;
		}

		private void SDF_Box() {

		}
	}
}