using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Number), true)]
public class NumberInspector : Editor {

	public Number test;

	public void OnEnable() {
		// test = (Number)target;
	}

	public override void OnInspectorGUI() {
		GUILayout.Label(test.ToString());
	}
}