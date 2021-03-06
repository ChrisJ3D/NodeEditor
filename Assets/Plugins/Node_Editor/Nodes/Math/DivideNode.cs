﻿using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Divide")]
	public class DivideNode : Node 
	{
		public const string ID = "DivideNode";
		public override string GetID { get { return ID; } }

		public Number numerator = 0f;
		public Number denominator = 0f;
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			DivideNode node = CreateInstance<DivideNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Divide";
			
			node.CreateInput ("Numerator", "Number");
			node.CreateInput ("Denominator", "Number");
			node.CreateOutput ("Quotient", "Number");
			
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
				numerator = RTEditorGUI.FloatField (GUIContent.none, numerator);
			InputKnob (0);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				GUILayout.Label (Inputs [1].name);
			else
				denominator = RTEditorGUI.FloatField (GUIContent.none, denominator);
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
				numerator = Inputs[0].connection.GetValue<Number> ();
			if (Inputs[1].connection != null)
				denominator = Inputs[1].connection.GetValue<Number> ();

			Outputs[0].SetValue<Number> (numerator / denominator);

			label = Outputs[0].GetValue(typeof(Number)).ToString();

			return true;
		}
	}
}