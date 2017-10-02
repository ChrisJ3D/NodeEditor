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

		public float length = 0.0f;
		
		public override Node Create (Vector2 pos) 
		{
			LengthNode node = CreateInstance<LengthNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Length";
			
			node.CreateInput ("Vector", typeof(object).AssemblyQualifiedName);
			node.CreateOutput ("Length", "Float");
			
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
			
			Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ())
				return false;

			if (Inputs[0].connection != null) {
				Type vectorType = Inputs[0].connection.GetValue ().GetType();

				if (vectorType == typeof(Vector2)) {
					Vector2 v = Inputs [0].connection.GetValue<Vector2>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y));
					Outputs[0].SetValue<float> (length);

				} else if (vectorType == typeof(Vector3)) {
					Vector3 v = Inputs [0].connection.GetValue<Vector3>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
					Outputs[0].SetValue<float> (length);

				} else if (vectorType == typeof(Vector4)) {
					Vector4 v = Inputs [0].connection.GetValue<Vector4>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z) + (v.w * v.w));
					Outputs[0].SetValue<float> (length);

				} else {
					return false;
				}
			}
			return true;
		}
	}
}