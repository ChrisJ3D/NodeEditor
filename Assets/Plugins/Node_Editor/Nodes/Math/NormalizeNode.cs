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

		public object normalizedVector = null;
		
		public override Node Create (Vector2 pos) 
		{
			NormalizeNode node = CreateInstance<NormalizeNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 50);
			node.name = "Normalize";
			
			node.CreateInput ("Vector", typeof(object).AssemblyQualifiedName);
			node.CreateOutput ("Normalized", typeof(object).AssemblyQualifiedName);
			
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
				float length = 0.0f;
				Type vectorType = Inputs[0].connection.GetValue ().GetType();

				if (vectorType == typeof(Vector2)) {
					Vector2 v = Inputs [0].connection.GetValue<Vector2>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y));
					Outputs[0].SetValue<Vector2> (v / length);

				} else if (vectorType == typeof(Vector3)) {
					Vector3 v = Inputs [0].connection.GetValue<Vector3>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
					Outputs[0].SetValue<Vector3> (v / length);

				} else if (vectorType == typeof(Vector4)) {
					Vector4 v = Inputs [0].connection.GetValue<Vector4>();
					length =  Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z) + (v.w * v.w));
					Outputs[0].SetValue<Vector4> (v / length);

				} else {
					return false;
				}
			}
			return true;
		}
	}
}