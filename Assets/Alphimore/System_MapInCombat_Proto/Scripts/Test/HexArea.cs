using UnityEngine;
using System.Collections;


public abstract class HexArea : MonoBehaviour {
	public abstract void Generate (HexCell cellPrefab, Vector2 offset, HexGrid grid);
}
