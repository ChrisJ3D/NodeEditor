using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNumber : ScriptableObject {
	public Number numberTest = new Number();
	public float floatTest = new float();
	public bool boolTest = new bool();

	public SaveNumber() {
		numberTest = 1235f;
		floatTest = 0.2f;
		boolTest = true;
	}
}