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

	Animator anim;
	
	public float jumpAmount, maxForce;

	Rigidbody [] bones;

	void Start()
	{
		anim = this.GetComponent<Animator>();
		bones = GetComponentsInChildren<Rigidbody>();
	}

	void Update()
	{
		moveSpeed = (isRunning) ? 15 : 5;

		anim.SetBool("isWalking", isWalking);
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isIdle", isIdle);
		anim.SetBool("isStrafing", isStrafing);
		anim.SetBool("isRagdoll", isRagdoll);



		if(!isRagdoll)
		{
			Vector3 newVelocity =(Input.GetAxis("Horizontal")*transform.right+Input.GetAxis("Vertical")*transform.forward).normalized;
			rigidbody.MovePosition(rigidbody.position + newVelocity * Time.deltaTime * moveSpeed);

			Vector3 eularVelocity = new Vector3(0, Input.GetAxis("Mouse X"), 0);
			Quaternion newRotation = Quaternion.Euler(eularVelocity);
			rigidbody.MoveRotation(rigidbody.rotation * newRotation);

			isWalking = (Input.GetAxis("Vertical") != 0) ? true : false;
			isStrafing = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0) ? true : false;
			isIdle = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) ? true : false;
			isRunning = (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0) ? true : false;

			if(Input.GetKeyDown(KeyCode.Space))
				rigidbody.velocity = new Vector3 (0, jumpAmount, 0);
		}

		if(Input.GetKeyDown(KeyCode.R))
			RagDoll();
	}
	
	void RagDoll()
	{
		isRagdoll = true;
		rigidbody.isKinematic = true;
		collider.enabled = false;
		anim.enabled = false;
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log(col.relativeVelocity.sqrMagnitude);
		if(col.relativeVelocity.sqrMagnitude > maxForce)
			RagDoll();
	}

}