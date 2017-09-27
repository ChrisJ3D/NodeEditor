using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor.SceneManagement;

namespace NodeEditorFramework.Standard
{
	[Node (false, "AMHQ/Load Scene")]
	public class LoadSceneNode : Node 
	{
		public const string ID = "LoadSceneNode";
		public override string GetID { get { return ID; } }

		public Example scene;
		
		public override Node Create (Vector2 pos) 
		{
			LoadSceneNode node = CreateInstance<LoadSceneNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 130, 100);
			node.name = "Load Scene";

			// Flow connections
			node.CreateInput ("Flow", "Flow", NodeSide.Left, 10);

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			// Display Connections
			// Start counter at 1 to ignore flow connections
			for (int inCnt = 1; inCnt < Inputs.Count; inCnt++)
				Inputs[inCnt].DisplayLayout ();

			// Get adjacent flow elements
			Node flowSource = Inputs[0].connection != null ? Inputs[0].connection.body : null;

			// Display adjacent flow elements
			GUILayout.Space(10f);
			GUILayout.Label("Scene");
			scene = (Example)UnityEditor.EditorGUILayout.EnumPopup (scene);
		}
		
		public override bool Calculate () 
		{
			// The following can NOT be used anymore until I implement conenction blocking though as the flow connections never have a value
	//		if (!allInputsReady ())
	//			return false;

			// Do your calc stuff

			// UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
			return true;
		}
	}

	// Connection Type only for visual purposes
	public class LoadSceneType : IConnectionTypeDeclaration 
	{
		public string Identifier { get { return "Load Scene"; } }
		public Type Type { get { return typeof(void); } }
		public Color Color { get { return Color.cyan; } }
		public string InKnobTex { get { return "Textures/In_Knob.png"; } }
		public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
	}

	public enum Example {
		HELLO,
		BANANA,
		HOUSE,
		LOVE
	}
}