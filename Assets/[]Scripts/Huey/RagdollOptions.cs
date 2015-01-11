using UnityEngine;
using System.Collections;

public class RagdollOptions : MonoBehaviour 
{
	public float newMass;

	[ContextMenu("Toggle ragdoll isKinematic")]
	void ToggelRagdoll()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody[] PlayerBones = player.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody Rbody in PlayerBones)
		{
			Rbody.isKinematic = !Rbody.isKinematic;
		}
	}

	[ContextMenu("Ragdoll add mass")]
	public void RagdollAddMass()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody[] PlayerBones = player.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody Rbody in PlayerBones)
		{
			Rbody.mass += newMass;
		}
	}
}