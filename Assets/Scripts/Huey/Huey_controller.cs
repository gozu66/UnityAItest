﻿using UnityEngine;
using System.Collections;

public class Huey_controller : MonoBehaviour 
{
	bool isWalking;
	bool isRunning;
	bool isIdle;
	bool isStrafing;
	bool isRagdoll;

	public float moveSpeed = 0.0f;
	public float strafeSpeed = 0.0f;

	CharacterController CharCont;
	Animator anim;

	public int xSpeedW = 10;
	public int xSpeedS = 5;
	public float Sensitivity = 1;

	Rigidbody [] bones;

	void Start()
	{
		CharCont = GetComponent<CharacterController>();
		anim = this.GetComponent<Animator>();
		bones = GetComponentsInChildren<Rigidbody>();
	}

	void Update()
	{
		xSpeedW = (isRunning) ? 20 : 10;

		anim.SetBool("isWalking", isWalking);
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isIdle", isIdle);
		anim.SetBool("isStrafing", isStrafing);
		anim.SetBool("isRagdoll", isRagdoll);

		moveSpeed = Input.GetAxis("Vertical") * Time.deltaTime * xSpeedW;
		strafeSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeedS;

		if(strafeSpeed == 0 || moveSpeed != 0){transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity);}

		CharCont.Move(transform.forward * moveSpeed);
		CharCont.Move(transform.right * strafeSpeed);

		isWalking = (moveSpeed != 0) ? true : false;
		isStrafing = (strafeSpeed != 0 || Input.GetAxis("Mouse X") != 0) ? true : false;
		isIdle = (moveSpeed == 0 && strafeSpeed == 0) ? true : false;
		isRunning = (Input.GetKey(KeyCode.LeftShift)) ? true : false;

//		if(Input.GetKeyDown(KeyCode.R))
//			RagDoll();
	}

	void RagDoll()
	{
		anim.enabled = !anim.enabled;
		foreach(Rigidbody r in bones)
		{
//			r.AddForce(Vector3.up * 1000, ForceMode.Force);
//			r.AddForce(transform.forward * 1000, ForceMode.Force);


		}
	}
}