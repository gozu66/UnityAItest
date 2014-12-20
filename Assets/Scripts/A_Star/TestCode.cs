using UnityEngine;
using System.Collections;

public class TestCode : MonoBehaviour 
{
	private Transform startPos, endPos;
	public Node startNode { get; set; }
	public Node goalNode { get; set; }

	public ArrayList PathArray;

	GameObject objStartCube, objEndCube;
	private float elapsedTime = 0.0f;

	public float intervalTime = 1.0f;

	void Start()
	{
		objStartCube = GameObject.FindGameObjectWithTag("Start");
		objEndCube = GameObject.FindGameObjectWithTag("End");

		PathArray = new ArrayList();
		FindPath();
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= intervalTime)
		{
			elapsedTime = 0.0f;
			FindPath();
		}
	}

	void FindPath()
	{
		startPos = objStartCube.transform;
		endPos = objEndCube.transform;

		startNode = new Node(GridManager.insatnce.GetGridCellCenter(GridManager.insatnce.GetGridIndex(startPos.position)));

		goalNode = new Node(GridManager.insatnce.GetGridCellCenter(GridManager.insatnce.GetGridIndex(endPos.position)));

		PathArray = AStar.FindPath(startNode, goalNode);
	}

	void OnDrawGizmos()
	{
		if(PathArray == null)
			return;

		if(PathArray.Count > 0)
		{
			int index = 1;
			foreach(Node node in PathArray)
			{
				if(index < PathArray.Count)
				{
					Node nextNode = (Node)PathArray[index];
					Debug.DrawLine(node.position, nextNode.position, Color.green);
					index++;
				}
			}
		}
	}
}