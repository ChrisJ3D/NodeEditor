using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Modulo")]
	public class ModuloNode : Node 
	{
		public const string ID = "moduloNode";
		public override string GetID { get { return ID; } }

		public float dividend = 0f;
		public float modDivisor = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			ModuloNode node = CreateInstance<ModuloNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Modulo";
			
			node.CreateInput ("Dividend", "Float");
			node.CreateInput ("modDivisor", "Float");
			node.CreateOutput ("Remainder", "Float");
			
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
				dividend = RTEditorGUI.FloatField (GUIContent.none, dividend);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				modDivisor = RTEditorGUI.FloatField (GUIContent.none, modDivisor);
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
				dividend = Inputs[0].connection.GetValue<float> ();
			if (Inputs[1].connection != null)
				modDivisor = Inputs[1].connection.GetValue<float> ();

			Outputs[0].SetValue<float> (dividend % modDivisor);

			label = Outputs[0].GetValue(typeof(float)).ToString();

			return true;
		}
	}
}