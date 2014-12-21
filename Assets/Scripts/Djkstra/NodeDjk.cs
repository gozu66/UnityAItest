using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeDjk : MonoBehaviour
{
	public List<GameObject> neighbors = new List<GameObject> ();
	
	public float nodeRadius = 50.0f;
	public LayerMask nodeLayerMask;
	public LayerMask collisionLayerMask;
	public float sphereCastRadius = 0.5f;
	
	public GameObject goal;
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, Vector3.one);
		foreach(GameObject neighbor in neighbors)
		{
			Gizmos.DrawLine(transform.position, neighbor.transform.position);
			Gizmos.DrawWireSphere(neighbor.transform.position, 0.25f);
		}
		
		if(goal)
		{
			Gizmos.color = Color.green;
			GameObject current = gameObject;
			Stack<GameObject> path = DijkstraAlgorythm.Dijkstra(GameObject.FindGameObjectsWithTag("Node"),gameObject,goal);
			
			Debug.Log("Got here:");
			Debug.Log(path);
			foreach(GameObject obj in path)
			{
				Debug.Log("Got here also!");
				Gizmos.DrawWireSphere(obj.transform.position,1.0f);
				Gizmos.DrawLine(current.transform.position, obj.transform.position);
				current = obj;
			}
		}
	}
	
	[ContextMenu ("Connect Node to Neighbors")]
	void FindNeighbors()
	{
		neighbors.Clear();
		
		Collider [] cols = Physics.OverlapSphere (transform.position, nodeRadius, nodeLayerMask);
		foreach(Collider node in cols)
		{
			if (node.gameObject != gameObject)
			{
				RaycastHit hit;
				Physics.Raycast(transform.position, (node.transform.position - transform.position),out hit, nodeRadius, collisionLayerMask);
				
				if (hit.transform != null)
				{
					if (hit.transform.gameObject == node.gameObject)
					{
						neighbors.Add (node.gameObject);
					}
				}
				
			}
		}
		
	}
	
}
