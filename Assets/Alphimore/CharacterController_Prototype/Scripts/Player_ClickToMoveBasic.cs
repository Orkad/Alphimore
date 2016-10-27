using UnityEngine;
using System.Collections;

public class Player_ClickToMoveBasic : MonoBehaviour 
{

	[SerializeField] private float _speedMove = 10f;

	private Vector3 _targetPosition;
	private bool _isMoving;

	private const int _LEFT_MOUSE_BUTTON = 0;

	private Plane _plane;
	private Ray _ray;
	private float _point = 0f;

	private NavMeshAgent _navAgent;

	//Variables function jump
	private float _jumpHeight = 0f;
	private bool _isJumping = false;

	void Start () 
	{
		_navAgent = GetComponent<NavMeshAgent>();
		_targetPosition = transform.position; //Position actuelle.
		_isMoving = false;
	}

	void Update () 
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

	private void MovingPlayer()
	{
		//Le personnage effectue une rotation pour être face à la cible du déplacement.
		transform.LookAt (_targetPosition);
		//On bouge le perso sur un vector 3 en direction de la position courante à la position ciblée multiplié par la vitesse.
		//transform.position = Vector3.MoveTowards (transform.position, _targetPosition, _speedMove * Time.deltaTime);
		_navAgent.SetDestination(_targetPosition);

		if (transform.position == _targetPosition)
		{
			_isMoving = false;
		}

		Debug.DrawLine (transform.position, _targetPosition, Color.red);

	}

	#region function jumpPlayer
	private void jumpPlayer()
	{
		
	}
	#endregion
}
