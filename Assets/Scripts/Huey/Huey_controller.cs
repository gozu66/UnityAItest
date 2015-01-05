using UnityEngine;
using System.Collections;

public class Huey_controller : MonoBehaviour 
{
	bool isWalking;
	bool isRunning;
	bool isIdle;

	public float moveSpeed = 0.0f;
	public float strafeSpeed = 0.0f;

	CharacterController CharCont;
	Animator anim;

	int xSpeed = 10;

	public float Sensitivity = 1;

	void Start()
	{
		CharCont = GetComponent<CharacterController>();
		anim = this.GetComponent<Animator>();
	}

	void Update()
	{
		xSpeed = (isRunning) ? 20 : 10;

		anim.SetBool("isWalking", isWalking);
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isIdle", isIdle);

		moveSpeed = Input.GetAxis("Vertical") * Time.deltaTime * xSpeed;
		strafeSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;

		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity);

		CharCont.Move(transform.forward * moveSpeed);
		CharCont.Move(transform.right * strafeSpeed);

		isWalking = (moveSpeed != 0) ? true : false;
		isIdle = (moveSpeed == 0) ? true : false;
		isRunning = (Input.GetKey(KeyCode.LeftShift)) ? true : false;
	}
}