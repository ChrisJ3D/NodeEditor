using System;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Effects/SDF/Box")]
	public class BoxNode : Node 
	{
		public const string ID = "BoxNode";
		public override string GetID { get { return ID; } }

		public Number width = new Number();
		public Number height = new Number();
		public Number depth = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			BoxNode node = CreateInstance<BoxNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 150);
			node.name = "Power";
			
			node.CreateInput ("Width", "Number");
			node.CreateInput ("Height", "Number");
			node.CreateInput ("Depth", "Number");
			node.CreateOutput ("Position", "Number");
			
			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			Inputs[0].DisplayLayout ();
			Inputs[1].DisplayLayout ();
			Inputs[2].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			Outputs [0].DisplayLayout (new GUIContent(label));
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();

			if (GUI.changed) {
					NodeEditor.RecalculateFrom (this);
			}
			
		}
		
		public override bool Calculate () 
		{

			if (Inputs[0].connection != null)
				width = Inputs[0].connection.GetValue<Number> ();
				
			if (Inputs[1].connection != null)
				height = Inputs[1].connection.GetValue<Number> ();

			if (Inputs[2].connection != null)
				depth = Inputs[2].connection.GetValue<Number> ();


			// Outputs[0].SetValue<Number> (SDF_Box);

			label = Outputs[0].GetValue<Number> ().ToString();

			return true;
		}

		private void SDF_Box() {

		}
	}
}