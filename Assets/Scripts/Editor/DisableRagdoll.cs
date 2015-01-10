using UnityEditor;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DisableRagdoll : MonoBehaviour 
{
	[MenuItem("Component/Toggel Ragdoll IsKinematic")]
	public static void ToggelRagdoll()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody[] PlayerBones = player.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody Rbody in PlayerBones)
		{
			Rbody.isKinematic = !Rbody.isKinematic;
		}
	}
}