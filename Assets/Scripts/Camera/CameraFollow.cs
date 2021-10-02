using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Transform playerTarget;

	[SerializeField]
	float offsetZ = -15f, offsetX = -5f, constantY = 5f, cameraLerpTime = 0.05f;

	// Use this for initialization
	void Awake () 
	{
		playerTarget = GameObject.FindGameObjectWithTag(Tags.Player_Tag).transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (playerTarget)
        {
			Vector3 targetPosition = new Vector3(playerTarget.position.x + offsetX, constantY, playerTarget.position.z + offsetZ);
			transform.position = Vector3.Lerp(transform.position, targetPosition, cameraLerpTime);
        }
	}
}
