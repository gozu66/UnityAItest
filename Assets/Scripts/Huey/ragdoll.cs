using UnityEngine;
using System.Collections;

public class ragdoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.R))
		{
			Rigidbody[]rigidB = GetComponentsInChildren<Rigidbody>();
			foreach(Rigidbody rrr in rigidB)
			{
				rrr.isKinematic = false;
			}
		}
	}
}
