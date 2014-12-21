using UnityEngine;
using System.Collections;
using System;

public class basicMove : MonoBehaviour 
{
	GameObject[] nodes;
	NavMeshAgent NV;
	int nodeIndex, nodeCount;
	bool moving;

	void Start()
	{
		nodes = FindObsWithTag("Node");
		NV = this.GetComponent<NavMeshAgent>();

		nodeCount = nodes.Length;
		nodeIndex = 0;
		NV.destination = nodes[0].transform.position;
		moving = true;
	}

	GameObject[] FindObsWithTag( string tag ) 
	{ 
		GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag); 
		Array.Sort( foundObs, CompareObNames ); 
		return foundObs; 
	}

	int CompareObNames( GameObject x, GameObject y ) 
	{ 
		return x.name.CompareTo( y.name ); 
	}

	void Update()
	{
		if(NV.remainingDistance==0 && moving)
		{
			moving = false;
			UpdatePath();
		}else{
			moving = true;
		}
	}

	void UpdatePath()
	{
		moving = false;
		if(nodeIndex >= nodes.Length-1)
		{
			NV.SetDestination(nodes[0].transform.position);
			nodeIndex = 0;
		}else{
			NV.SetDestination(nodes[nodeIndex+1].transform.position);
			nodeIndex++;
		}
	}
}