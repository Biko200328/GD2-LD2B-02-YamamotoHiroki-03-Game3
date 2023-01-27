using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int ItemCount;
	FloorManager floorManager;

	public TextMesh num;
	public GameObject numObj;

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
		num.text = "" + ItemCount;
		if(ItemCount <= 0)
		{
			numObj.gameObject.SetActive(false);
		}
		else
		{
			numObj.gameObject.SetActive(true);
		}
	}

	public void Repair()
	{
		floorManager.time += ItemCount * 10;
		ItemCount = 0;
	}
}
