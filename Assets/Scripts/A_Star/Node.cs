﻿using UnityEngine; 
using System.Collections;
using System;

public class Node : IComparable 
{
	public float nodetotalCost;
	public float estimatedCost;
	public bool bObstacle;
	public Node parent;
	public Vector3 position;

	public Node ()
	{

		this.estimatedCost = 0.0f;
		this.nodetotalCost = 1.0f;
		this.bObstacle = false;
		this.parent = null;
	}

	public Node (Vector3 pos)
	{
		estimatedCost = 0.0f;
		this.nodetotalCost = 1.0f;
		this.bObstacle = false;
		this.parent = null;
		this.position = pos;
	}

	public void MarkAsObstacle()
	{
		this.bObstacle = true;
	}

	public int CompareTo(object obj)
	{
		Node node = (Node)obj;
		//Negative value means object comes before this in sort order
		if(this.estimatedCost < node.estimatedCost)
			return -1;
		//Negative value means object comes after this in sort order
		if(this.estimatedCost > node.estimatedCost)
			return 0;

		return 0;
	}
}
