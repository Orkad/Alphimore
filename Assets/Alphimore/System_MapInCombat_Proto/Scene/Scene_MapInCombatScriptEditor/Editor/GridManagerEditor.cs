using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Transform))]
public class GridManagerEditor : Editor
{


  public override void OnInspectorGUI()
  {
    GridManager gm = ((Transform)target).GetComponent<GridManager>();
    if (gm != null)
    {

      if (GUILayout.Button("GENERATE GRID"))
      {
        gm.CreateGrid();
        //((Transform)target).transform.GetChild(0).gameObject.AddComponent<EventBlock>();
        //((Transform)target).gameObject
      }

      if (GUILayout.Button("CLEAR GRID"))
      {
        gm.ClearGrid();
        //((Transform)target).transform.GetChild(0).gameObject.AddComponent<EventBlock>();
        //((Transform)target).gameObject
      }
    }
    else
    {
      Hexa hex = ((Transform)target).GetComponent<Hexa>();

      if (hex != null)
      {
        if (GUILayout.Button("DELETE HEXA"))
        {
          GridManager gmgrid = FindObjectOfType<GridManager>();
          gmgrid.DeleteOneGrid(((Transform)target).name);
          return;
          //gm.CreateGrid();
          //((Transform)target).transform.GetChild(0).gameObject.AddComponent<EventBlock>();
          //((Transform)target).gameObject
        }
      }

    }

    // Show default inspector property editor
    DrawDefaultInspector();
  }
}
