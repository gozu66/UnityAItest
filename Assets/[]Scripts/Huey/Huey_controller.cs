using UnityEngine;
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

//	CharacterController CharCont;

	Animator anim;

	public int xSpeedW = 10;
	public int xSpeedS = 5;
	public float Sensitivity = 1;

	Rigidbody [] bones;

	void Start()
	{
//		CharCont = GetComponent<CharacterController>();
		anim = this.GetComponent<Animator>();
		bones = GetComponentsInChildren<Rigidbody>();
	}

	void Update()
	{
		xSpeedW = (isRunning) ? 100 : 100;

		anim.SetBool("isWalking", isWalking);
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isIdle", isIdle);
		anim.SetBool("isStrafing", isStrafing);
		anim.SetBool("isRagdoll", isRagdoll);


		if(!isRagdoll)
		{
//			moveSpeed = Input.GetAxis("Vertical") * Time.deltaTime + xSpeedW;
//			strafeSpeed = Input.GetAxis("Horizontal") * Time.deltaTime + xSpeedS;
//			Debug.Log(Input.GetAxis("Vertical"));

//			if(strafeSpeed == 0 || moveSpeed != 0){transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity);}

//			CharCont.Move(transform.forward * moveSpeed);
//			CharCont.Move(transform.right * strafeSpeed);


//			if(Input.GetAxis("Vertical"))

			rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * strafeSpeed,0,Input.GetAxis("Vertical") * moveSpeed);
//				rigidbody.AddForce((transform.forward * xSpeedW), ForceMode.Force);

//			if(Input.GetKey(KeyCode.A))
//				rigidbody.AddForce((transform.right * xSpeedS), ForceMode.Force);

//			if(Input.GetKey(KeyCode.S))
//				rigidbody.AddForce((-transform.forward * xSpeedW), ForceMode.Force);
			
//			if(Input.GetKey(KeyCode.D))
//				rigidbody.AddForce((-transform.right * xSpeedS), ForceMode.Force);


			isWalking = (moveSpeed != 0) ? true : false;
			isStrafing = (strafeSpeed != 0 || Input.GetAxis("Mouse X") != 0) ? true : false;
			isIdle = (moveSpeed == 0 && strafeSpeed == 0) ? true : false;
			isRunning = (Input.GetKey(KeyCode.LeftShift)) ? true : false;
		}

		if(Input.GetKeyDown(KeyCode.R))
			RagDoll();
	}
	
	void RagDoll()
	{
		isRagdoll = true;
//		CharCont.enabled = false;
		anim.enabled = false;
		foreach(Rigidbody r in bones)
		{

		}
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log(col.relativeVelocity.magnitude.ToString("0"));
	}

}