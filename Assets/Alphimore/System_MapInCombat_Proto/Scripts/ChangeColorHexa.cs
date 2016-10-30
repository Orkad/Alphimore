using UnityEngine;
using System.Collections;

public class ChangeColorHexa : MonoBehaviour
{
	private Renderer _rend;

	void Start ()
	{
		_rend = GetComponent<Renderer> ();
	}

	private void OnMouseEnter()
	{
		_rend.material.color = Color.red;
	}

	private void OnMouseOver()
	{
		_rend.material.color -= new Color (0.1f, 0, 0) * Time.deltaTime;
	}

	private void OnMouseExit()
	{
		_rend.material.color = Color.white;
	}
}
