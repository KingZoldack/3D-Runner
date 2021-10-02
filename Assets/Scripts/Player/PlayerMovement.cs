using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	float _movementSpeed = 5f;

	Rigidbody _rb;

	
	// Use this for initialization
	void Awake () 
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MovePlayer();
	}

	void MovePlayer()
    {
		_rb.velocity = new Vector3(_movementSpeed, _rb.velocity.y, 0f);
    }
}
