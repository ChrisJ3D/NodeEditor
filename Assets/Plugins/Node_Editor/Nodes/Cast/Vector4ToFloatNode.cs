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

		public Number x = new Number();
		public Number y = new Number();
		public Number z = new Number();
		public Number w = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			Vector4ToFloatNode node = CreateInstance<Vector4ToFloatNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 100);
			node.name = "Vector to Float";
			
			node.CreateInput ("", "Number");
			node.CreateOutput ("X", "Number");
			node.CreateOutput ("Y", "Number");
			node.CreateOutput ("Z", "Number");
			node.CreateOutput ("W", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				Inputs[0].DisplayLayout();
			else {
				x = RTEditorGUI.FloatField ("", x);
				y = RTEditorGUI.FloatField ("", y);
				z = RTEditorGUI.FloatField ("", z);
				w = RTEditorGUI.FloatField ("", w);
			}
		
			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout (new GUIContent(x));
			Outputs [1].DisplayLayout (new GUIContent(y));
			Outputs [2].DisplayLayout (new GUIContent(z));
			Outputs [3].DisplayLayout (new GUIContent(w));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed)
				NodeEditor.RecalculateFrom (this);
		}
		
		public override bool Calculate () 
		{
			if (Inputs[0].connection != null) {
				x = Inputs[0].connection.GetValue<Number> ().x;
				y = Inputs[0].connection.GetValue<Number> ().y;
				z = Inputs[0].connection.GetValue<Number> ().z;
				w = Inputs[0].connection.GetValue<Number> ().w;
			}

			Outputs[0].SetValue<Number> (x);
			Outputs[1].SetValue<Number> (y);
			Outputs[2].SetValue<Number> (z);
			Outputs[3].SetValue<Number> (w);

			label = Outputs[0].GetValue<Number>().ToString();

			return true;
		}
	}
}