using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Add")]
	public class AddNode : Node 
	{
		public const string ID = "addNode";
		public override string GetID { get { return ID; } }

		public float summand1 = 0f;
		public float summand2 = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			AddNode node = CreateInstance<AddNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Add";
			
			node.CreateInput ("Summand 1", "Float");
			node.CreateInput ("Summand 2", "Float");
			node.CreateOutput ("Sum", "Float");
			
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
				summand1 = RTEditorGUI.FloatField (GUIContent.none, summand1);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				summand2 = RTEditorGUI.FloatField (GUIContent.none, summand2);
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
				summand1 = Inputs[0].connection.GetValue<float> ();
			if (Inputs[1].connection != null)
				summand2 = Inputs[1].connection.GetValue<float> ();

			Outputs[0].SetValue<float> (summand1 + summand2);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}