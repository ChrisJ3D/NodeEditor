using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Normalize")]
	public class NormalizeNode : Node 
	{
		public const string ID = "NormalizeNode";
		public override string GetID { get { return ID; } }

		public Number normalizedVector = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			NormalizeNode node = CreateInstance<NormalizeNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Normalize";
			
			node.CreateInput ("Vector", "Number");
			node.CreateOutput ("Normalized", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			Inputs [0].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout (new GUIContent(label));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if(GUI.changed) {
				NodeEditor.RecalculateFrom(this);
			}
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ()) {
				label = "";
				return false;
			}

			if (Inputs[0].connection != null) {
				float length = 0.0f;
				Number v = Inputs [0].connection.GetValue<Number>();
				length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z) + (v.w * v.w));
				Outputs[0].SetValue<Number> (v / length);
			}

			label = Outputs[0].GetValue<Number> ().ToString();

			return true;
		}
	}
}