using UnityEngine;
using System.Collections.Generic;

public class HexGridManager : MonoBehaviour
{
	#region Variables
	//Variables contains the hexagone prefab.
	public HexCell hexPrefab;

	//Variables contains the sizes of the one hexagone.
	public float hexWidth = 2.0f;
	public float hexHeight = 2.0f;

	//Variables contains the gaps between the hexas.
	[SerializeField] private float gap = 0.0f;
	private float _offset;

	//Variables contains the start position of the grid.
	private Vector3 _startPos;

	private bool IsShown = false;

	public List<GameObject> GridList;
	#endregion
}

