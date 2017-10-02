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

		public float summand1 = 0f;
		public float summand2 = 0f;
		
		public override Node Create (Vector2 pos) 
		{
			AddNode node = CreateInstance<AddNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Add";
			
			NodeInput.Create(node, "Summand 1", typeof(object).AssemblyQualifiedName);
			NodeInput.Create(node, "Summand 2", typeof(object).AssemblyQualifiedName);

			// node.CreateInput ("Summand 1", "Float");
			// node.CreateInput ("Summand 2", "Float");

			node.CreateOutput("Sum", "Float");
			
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
			object input1 = null;
			object input2 = null;

			if (!allInputsReady ())
				return false;

			if (Inputs[0].connection != null) {
				input1 = Inputs[0].connection.GetValue();
			}

			if (Inputs[1].connection != null) {
				input2 = Inputs[1].connection.GetValue();
			}

			input1 = (float)Convert.ChangeType(input1, typeof(float));
			input2 = (float)Convert.ChangeType(input2, typeof(float));

			float result = (float)input1 + (float)input2;
			Outputs[0].SetValue (result);

			return true;
		}
	}
}