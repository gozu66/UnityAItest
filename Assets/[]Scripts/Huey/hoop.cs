using UnityEngine;
using System.Collections;

public class hoop : MonoBehaviour 
{
	public AudioClip horn;
	bool played = false;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && !played)
		{
			played = true;
			AudioSource.PlayClipAtPoint(horn, transform.position);
			other.SendMessage("Ragdoll", SendMessageOptions.DontRequireReceiver);
		}
	}
}
