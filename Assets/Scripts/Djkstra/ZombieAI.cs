using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAI : MonoBehaviour
{
	public float speed = 1.0f;
	public float turnSpeed = 30.0f;
	public float sphereCastRadius = 0.5f;
	
	private GameObject goal;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		//If the dude can be "seen" (Via raycast) then chase
		RaycastHit hit;
		

		Physics.SphereCast(transform.position, sphereCastRadius, player.transform.position - transform.position, out hit);

		if(hit.collider.tag == "Player")
		{
			Vector3 playerPosition = player.transform.position;
			Vector3 playerDirection = playerPosition - transform.position;
			playerDirection.y = 0.0f;
			Vector3 normalizedPlayerDirection = playerDirection.normalized;
			transform.position += transform.forward * speed * Time.deltaTime;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(normalizedPlayerDirection), turnSpeed*Time.deltaTime);
			gameObject.GetComponent<CurrentNode>().currentNode = null;
		}
		else
		{
			//Traverse to next node in path to player node
			Stack<GameObject> path = DijkstraAlgorythm.Dijkstra(
				GameObject.FindGameObjectsWithTag("Node"),
				gameObject.GetComponent<CurrentNode>().currentNode,
				player.GetComponent<CurrentNode>().currentNode);
			if(path != null)
			{
				goal = path.Pop();
				Vector3 goalPosition = goal.transform.position;
				Vector3 goalDirection = goalPosition - transform.position;
				goalDirection.y = 0.0f;
				Vector3 normalizedGoalDirection = goalDirection.normalized;
				transform.position += transform.forward * speed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(normalizedGoalDirection), turnSpeed*Time.deltaTime);
			}
		}
	}
	
	void OnDrawGizmos()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, goal.transform.position);
		
		RaycastHit hit;
		

		Physics.SphereCast(transform.position, sphereCastRadius, player.transform.position - transform.position, out hit);

		if(hit.collider.tag != "Player")
		{
			Gizmos.color = Color.red;
		}

		Gizmos.DrawLine(transform.position, player.transform.position);
	}
}
