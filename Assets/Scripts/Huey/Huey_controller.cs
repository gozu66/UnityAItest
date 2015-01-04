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

	void Start()
	{
		CharCont = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		anim.SetBool("isWalking", isWalking);
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isIdle", isIdle);


		moveSpeed = Input.GetAxis("Vertical") * Time.deltaTime * 10;
		strafeSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * 10;


		CharCont.Move(transform.forward * moveSpeed);
//		CharCont.Move(transform.right * strafeSpeed);

		transform.Rotate(Vector3.up, strafeSpeed * 5);
	}
}