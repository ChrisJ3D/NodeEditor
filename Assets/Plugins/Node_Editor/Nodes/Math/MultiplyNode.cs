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

		public Number factor1 = 0f;
		public Number factor2 = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			MultiplyNode node = CreateInstance<MultiplyNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Multiply";
			
			node.CreateInput ("Factor 1", "Number");
			node.CreateInput ("Factor 2", "Number");
			node.CreateOutput ("Product", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			//	GUILayout.Label (label);

			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			// Inputs [0].DisplayLayout ();
			// Inputs [1].DisplayLayout();

			if (Inputs [0].connection != null)
				GUILayout.Label (Inputs [0].name);
			else
				factor1 = RTEditorGUI.FloatField (GUIContent.none, factor1);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				factor2 = RTEditorGUI.FloatField (GUIContent.none, factor2);
			InputKnob (1);

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ())
				return false;

			if (Inputs[0].connection != null)
				factor1 = Inputs[0].connection.GetValue<Number> ();
			if (Inputs[1].connection != null)
				factor2 = Inputs[1].connection.GetValue<Number> ();

			Outputs[0].SetValue<Number> (factor1 * factor2);

			return true;
		}
	}
}