using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int ItemCount;
	FloorManager floorManager;
	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, false);
		Application.targetFrameRate = 60;

		floorManager = GetComponent<FloorManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Repair()
	{
		floorManager.time += ItemCount * 10;
		ItemCount = 0;
	}
}
