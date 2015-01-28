using UnityEngine;
using System.Collections;

public class LOD : MonoBehaviour 
{
	Camera cam;
	public float dist, speed, step;
	Vector3 myPos, camPos;
	public GameObject[] LODlist = new GameObject[5];

	void Start()	{
		cam = Camera.main;
	}

	void Update()	{
		Vector3 myPos = transform.position;
		Vector3 camPos = cam.transform.position;
		dist = Vector3.Distance(myPos, camPos);

		if(dist < 2 * step){
			LODlist[0].active = true;
			LODlist[1].active = false;
			LODlist[2].active = false;
			LODlist[3].active = false;
			Debug.Log("high");
		}
		if(dist < 3 * step && dist > 2 * step){
			LODlist[0].active = false;
			LODlist[1].active = true;
			LODlist[2].active = false;
			LODlist[3].active = false;
			Debug.Log("high-med");
		}
		if(dist < 5 * step && dist > 3 * step){
			LODlist[0].active = false;
			LODlist[1].active = false;
			LODlist[2].active = true;
			LODlist[3].active = false;
			Debug.Log("low-med");
		}
		if(dist > 5 * step){
			LODlist[0].active = false;
			LODlist[1].active = false;
			LODlist[2].active = false;
			LODlist[3].active = true;
			Debug.Log("low");
		}

		cam.transform.localPosition += (cam.transform.forward * speed) * Input.GetAxis("Vertical");
	}
	
}