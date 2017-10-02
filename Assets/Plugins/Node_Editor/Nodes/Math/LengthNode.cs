using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Math/Length")]
	public class LengthNode : Node 
	{
		public const string ID = "LengthNode";
		public override string GetID { get { return ID; } }

		public Number length = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			LengthNode node = CreateInstance<LengthNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Length";
			
			node.CreateInput ("Vector", "Number");
			node.CreateOutput ("Length", "Number");
			
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
			
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ()) {
				label = "";
				return false;
			}

			if (Inputs[0].connection != null) {
				Number v = Inputs [0].connection.GetValue<Number>();
				length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z) + (v.w * v.w));
				Outputs[0].SetValue<Number> (length);
			}

			label = length.ToString();
				
			return true;
		}
	}
}