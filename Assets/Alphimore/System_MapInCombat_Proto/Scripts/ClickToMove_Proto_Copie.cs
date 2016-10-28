﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Class containing the "click to move" which is the basic movement (out of combat) for Alphimore.
/// </summary>

public class ClickToMove_Proto_Copie : MonoBehaviour 
{
	#region Variables
	//Variables for the movement
	private Vector3 _targetPosition;
	private bool _isMoving;
	private Plane _plane;
	private Ray _ray;
	private float _point = 0f;

	//Variable holding the left mouse click 
	private const int _LEFT_MOUSE_BUTTON = 0;

	//Variable containing the navmeshagent for around obstacles.
	private NavMeshAgent _navAgent;
	#endregion

	#region function Start
	void Start () 
	{
		_navAgent = GetComponent<NavMeshAgent>();
		_targetPosition = transform.position; //Current position
		_isMoving = false;
	}
	#endregion

	#region function Update
	void Update () 
	{
		MoveManagement ();
	}
	#endregion

	#region function SetTargetPosition
	private void SetTargetPosition()
	{
		_plane = new Plane (Vector3.up, transform.position);
		_ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Get position mouse screen

		if (_plane.Raycast (_ray, out _point))
		{
			_targetPosition = _ray.GetPoint (_point);
		}

		_isMoving = true;
	}
	#endregion

	#region function MovingPlayer
	private void MovingPlayer()
	{
		//The character is rotated to be facing the target displacement.
		transform.LookAt (_targetPosition);
		//The navmeshagent the path to the selected destination (where you click with the mouse).
		_navAgent.SetDestination(_targetPosition);

		if (transform.position == _targetPosition)
		{
			_isMoving = false;
		}

		Debug.DrawLine (transform.position, _targetPosition, Color.red);
	}
	#endregion

	#region function MoveManagement
	private void MoveManagement()
	{
		if (Input.GetMouseButton (_LEFT_MOUSE_BUTTON))
		{
			SetTargetPosition ();
		}

		if (_isMoving)
		{
			MovingPlayer ();
		}
	}
	#endregion
}