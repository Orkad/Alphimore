﻿using UnityEngine;

public class GridManager : MonoBehaviour
{
	#region Variables
	//Variables contains the hexagone prefab.
	[SerializeField] private Transform hexPrefab;

	// Variables contains the dimensions of the Grid
	[SerializeField] private int gridWidth = 11;
	[SerializeField] private int gridHeight = 11;

	//Variables contains the sizes of the one hexagone.
	private float hexWidth = 1.732f;
	private float hexHeight = 2.0f;

	//Variables contains the gaps between the hexas.
	[SerializeField] private float gap = 0.0f;
	private float _offset;

	//Variables contains the start position of the grid.
	private Vector3 _startPos;
	#endregion

	#region fucntion Start
	void Start()
	{
		AddGap();
		CalcStartPosGrid();
		CreateGrid();
	}
	#endregion

	#region function AddGap
	private void AddGap()
	{
		hexWidth += hexWidth * gap;
		hexHeight += hexHeight * gap;
	}
	#endregion

	#region function CalcStartPos
	private void CalcStartPosGrid()
	{
		_offset = 0;

		if (gridHeight / 2 % 2 != 0)
		{
			_offset = hexWidth / 2;
		}

		float x = -hexWidth * (gridWidth / 2) - _offset;
		float z = hexHeight * 0.75f * (gridHeight / 2);

		_startPos = new Vector3(x, 0, z);
	}
	#endregion

	#region function CalcWorldPos
	private Vector3 CalcWorldPos(Vector2 gridPos)
	{
		_offset = 0;

		if (gridPos.y % 2 != 0)
		{
			_offset = hexWidth / 2;
		}

		float x = _startPos.x + gridPos.x * hexWidth + _offset;
		float z = _startPos.z - gridPos.y * hexHeight * 0.75f;

		//Return position x, y, z of the grid
		return new Vector3(x, 0.1f, z);
	}
	#endregion

	#region function CreateGrid
	private void CreateGrid()
	{
		for (int y = 0; y < gridHeight; y++)
		{
			for (int x = 0; x < gridWidth; x++)
			{
				Transform hex = Instantiate(hexPrefab) as Transform;
				Vector2 gridPos = new Vector2(x, y);
				hex.position = CalcWorldPos(gridPos);
				hex.parent = this.transform;
				hex.name = "Hexagon" + x + "|" + y;
			}
		}
	}
	#endregion
}
