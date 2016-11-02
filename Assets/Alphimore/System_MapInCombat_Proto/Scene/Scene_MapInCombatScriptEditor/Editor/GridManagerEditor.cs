using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
  	public override void OnInspectorGUI()
  	{
		GridManager gridManager = target as GridManager;
		if (GUILayout.Button("GENERATE GRID"))
		{
			gridManager.CreateGrid();
		}
		if (GUILayout.Button("CLEAR GRID"))
		{
			gridManager.ClearGrid();
		}
		GUILayout.Label ("This is a Label in a Custom Editor");
		DrawDefaultInspector ();
		return;
  	}
}
