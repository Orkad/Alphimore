using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour 
{
	private bool _isJumping = false;
	private Rigidbody rb;


	void OnTriggerEnter(Collider player)
	{
		if (player.CompareTag ("Player")) 
		{
			JumpingController ();
		}
	}

	private void JumpingController()
	{
		_isJumping = true;
		rb.velocity = new Vector3(0, 8,0);
	}

	/*void OnTriggerStay (Collider player)
	{
		_isJumping = false;
	}*/
}
