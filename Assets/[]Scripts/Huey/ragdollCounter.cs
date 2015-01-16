using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ragdollCounter : MonoBehaviour {

	public static Text uitext;
	public static int timesWrecked;

	void Start()
	{
		uitext = GetComponent<Text>();

		timesWrecked = 0;
		uitext.text = "Times wrecked : " + timesWrecked;
	}

	public static void GetWrecked()
	{
		timesWrecked++;
		uitext.text = "Times wrecked : " + timesWrecked;
	}
}
