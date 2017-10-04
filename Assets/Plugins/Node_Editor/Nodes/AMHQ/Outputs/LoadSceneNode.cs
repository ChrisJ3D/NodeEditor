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
		public override string Title { get { return "Load Scene"; } }
		public override Vector2 DefaultSize { get { return new Vector2 (130, 100); } }

		[ConnectionKnob("Flow In", Direction.In, "Flow", NodeSide.Left, 10)]
		public ConnectionKnob flowIn;

		public Example scene;
		
		public override void NodeGUI () 
		{
			GUILayout.BeginHorizontal();

			flowIn.DisplayLayout();

			GUILayout.EndHorizontal();

			GUILayout.Label("Scene");
			scene = (Example)UnityEditor.EditorGUILayout.EnumPopup (scene);
		}
		
		public override bool Calculate () 
		{
			
			// UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
			return true;
		}
	}

	// Connection Type only for visual purposes

	public enum Example {
		HELLO,
		BANANA,
		HOUSE,
		LOVE
	}
}