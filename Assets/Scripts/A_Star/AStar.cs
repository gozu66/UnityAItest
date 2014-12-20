using UnityEngine;
using System.Collections;

public class AStar 
{
	public static PriorityQueue closedList, openList;

	private static float HeuristicEstimateCost(Node curNode, Node goal)
	{
		Vector3 vecCost = curNode.position - goal.position;
		return vecCost.magnitude;
	}

	public static ArrayList FindPath(Node curNode, Node goal)
	{
		openList = new PriorityQueue();
		Node node = null;

		while(openList.Length != 0)
		{
			node = openList.First();

			if(node.position == goal.position)
			{
				return CalculatePath(node);
			}

			//Create an ArrayList to store the neighboring nodes
			ArrayList neighbours = new ArrayList();

			GridManager.insatnce.GetNeighbours(node, neighbours);

			for(int i = 0; i < neighbours.Count; i++)
			{
				Node neighbourNode = (Node)neighbours[i];

				if(!closedList.Contains(neighbourNode))
				{
					float cost = HeuristicEstimateCost(node, neighbourNode);				                                

					float totalCost = node.nodetotalCost + cost;
					float neighbourNodeEstCost = HeuristicEstimateCost(neighbourNode, goal);

					neighbourNode.nodetotalCost = totalCost;
					neighbourNode.parent = node;
					neighbourNode.estimatedCost = totalCost + neighbourNodeEstCost;

					if(!openList.Contains(neighbourNode))
					{
						openList.Push(neighbourNode);
					}
				}
			}
			//push node to closed list
			closedList.Push(node);
			//and remove for open list
			openList.Remove(node);
		}

		if(node.position != goal.position)
		{
			Debug.LogError("Goal Not Found");
			return null;
		}
		return CalculatePath(node);
	}

	private static ArrayList CalculatePath(Node node)
	{
		ArrayList list = new ArrayList();
		while(node != null)
		{
			list.Add(node);
			node = node.parent;
		}
		list.Reverse();
		return list;
	}
}