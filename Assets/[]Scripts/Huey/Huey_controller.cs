using UnityEngine;
using System.Collections;

public class Huey_controller : MonoBehaviour 
{
	bool isWalking;
	bool isRunning;
	bool isIdle;
	bool isStrafing;
	bool isRagdoll;

	float moveSpeed, strafeSpeed;

	Animator anim;
	
	public float jumpAmount, maxForce;
	public float sensitivity;

	Rigidbody [] bones;

	Vector3 newVelocity;

	public AudioClip[] ouch;

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
			newVelocity =(Input.GetAxis("Horizontal")*transform.right+Input.GetAxis("Vertical")*transform.forward).normalized;
			rigidbody.MovePosition(rigidbody.position + newVelocity * Time.deltaTime * moveSpeed);


			Vector3 eularVelocity = new Vector3(0, Input.GetAxis("Mouse X")*sensitivity, 0);
			Quaternion newRotation = Quaternion.Euler(eularVelocity);
			rigidbody.MoveRotation(rigidbody.rotation * newRotation);

			isWalking = (Input.GetAxis("Vertical") != 0) ? true : false;
			isStrafing = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0) ? true : false;
			isIdle = (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) ? true : false;
			isRunning = (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0) ? true : false;

			if(isIdle)
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			if(!isRagdoll)
			{
				Ragdoll();
			}
			else
			{
				ReturnRagdoll();
			}
		}
	}
	
	void Ragdoll()
	{
		isRagdoll = true;
		rigidbody.isKinematic = true;

		collider.enabled = false;
		anim.enabled = false;

		foreach(Rigidbody bone in bones)
		{
			bone.AddForce(newVelocity * 1000, ForceMode.Impulse);
		}

		int i = Random.Range(0,3);
		AudioSource.PlayClipAtPoint(ouch[i], transform.position);

		ragdollCounter.GetWrecked();
	}

	void ReturnRagdoll()
	{
		transform.position = new Vector3(bones[1].position.x, bones[1].position.y, bones[1].position.z);
		isRagdoll = false;
		rigidbody.isKinematic = false;
		collider.enabled = true;
		anim.enabled = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.relativeVelocity.sqrMagnitude > maxForce)
			Ragdoll();
	}
}