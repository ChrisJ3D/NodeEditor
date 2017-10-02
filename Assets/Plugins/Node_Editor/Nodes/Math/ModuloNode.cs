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

		public Number dividend = new Number();
		public Number modDivisor = new Number();
		protected string label = "";
		
		public override Node Create (Vector2 pos) 
		{
			ModuloNode node = CreateInstance<ModuloNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 70);
			node.name = "Modulo";
			
			node.CreateInput ("Dividend", "Number");
			node.CreateInput ("modDivisor", "Number");
			node.CreateOutput ("Remainder", "Number");

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			GUILayout.Space(5f);

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			if (Inputs [0].connection != null)
				Inputs [0].DisplayLayout ();
			else
				dividend = RTEditorGUI.FloatField (GUIContent.none, dividend);

			GUILayout.Space(5f);
			
			// --
			if (Inputs [1].connection != null)
				Inputs [1].DisplayLayout ();
			else
				modDivisor = RTEditorGUI.FloatField (GUIContent.none, modDivisor);

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

			if (Inputs[0].connection != null)
				dividend = Inputs[0].connection.GetValue<Number> ();

			if (Inputs[1].connection != null)
				modDivisor = Inputs[1].connection.GetValue<Number> ();

			Outputs[0].SetValue<Number> (dividend % modDivisor);

			label = Outputs[0].GetValue<Number> ().ToString();

			return true;
		}
	}
}