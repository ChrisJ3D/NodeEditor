using System;
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

		public Number summand1 = new Number();
		public Number summand2 = new Number();
		
		public override Node Create (Vector2 pos) 
		{
			AddNode node = CreateInstance<AddNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Add";
			
			NodeInput.Create(node, "Summand 1", "Number");
			NodeInput.Create(node, "Summand 2", "Number");

			// node.CreateInput ("Summand 1", "Float");
			// node.CreateInput ("Summand 2", "Float");

			node.CreateOutput("Sum", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
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

			if (GUI.changed) {
				NodeEditor.RecalculateFrom(this);
			}
			
		}
		
		public override bool Calculate () 
		{
			if (Inputs[0].connection != null) {
				summand1 = Inputs[0].connection.GetValue<Number>();
			}

			if (Inputs[1].connection != null) {
				summand2 = Inputs[1].connection.GetValue<Number>();
			} 
			
			Outputs[0].SetValue<Number> (summand1 + summand2);

			return true;
		}
	}
}