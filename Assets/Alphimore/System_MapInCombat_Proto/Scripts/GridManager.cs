using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
	#region Variables
	//Variables contains the hexagone prefab.
	public GameObject hexPrefab;

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

  private bool IsShown = false;

  public List<GameObject> GridList;
	#endregion

	#region fucntion Start_Update
	void Start()
	{
		AddGap();
		CalcStartPosGrid();
		CreateGrid();

    IsShown = true;

  }

  void Update()
  {
    if (Input.GetKeyUp(KeyCode.G ))
    {
      IsShown ^= true;
      for (int i = 0; i < GridList.Count; i++)
      {
        GridList[i].SetActive(IsShown);
      }
    }
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
		return new Vector3(x, transform.position.y, z);
	}
	#endregion

	#region function CreateGrid
	private void CreateGrid()
	{
    GridList = new List<GameObject>();

    for (int y = 0; y < gridHeight; y++)
		{
			for (int x = 0; x < gridWidth; x++)
			{
				GameObject hex =  Instantiate(hexPrefab, CalcWorldPos(new Vector2(x, y)),Quaternion.FromToRotation(Vector3.forward,Vector3.up), this.transform) as GameObject;
				/*Vector2 gridPos = new Vector2(x, y);
				hex.transform.position = CalcWorldPos(gridPos);
				hex.transform.parent = this.transform;*/
				hex.name = "Hexagon" + x + "|" + y;
        hex.GetComponent<Hexa>().MapPosX = x;
        hex.GetComponent<Hexa>().MapPosY = y;
        GridList.Add(hex);

      }
		}


  }
	#endregion
}
