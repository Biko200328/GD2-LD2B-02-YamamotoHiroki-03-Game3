using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int ItemCount { private set; get; }
	public bool isCreate = false;
	FloorManager floorManager;

	private TextMesh numText;
	private GameObject numObject;
	public GameObject numPrefab;

	GameObject player;

	SceneController sceneController;

	public GameObject mapObject;
	public GameObject mapPrefab1;
	public GameObject mapPrefab2;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1024, 864, false);
		Application.targetFrameRate = 60;

		player = GameObject.Find("Player");

		floorManager = GetComponent<FloorManager>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		mapObject = Instantiate(mapPrefab1, transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			sceneController.sceneChange("GameScene");
		}
	}

	public void AddItemCount(int num = 1)
	{
		if (ItemCount == 0)
		{
			numObject = Instantiate(numPrefab, player.transform.position, Quaternion.identity);
			numText = numObject.GetComponent<TextMesh>();
			isCreate = true;
		}
		ItemCount++;
		numText.text = "" + ItemCount;
	}

	//public int GetItemCout()
	//{
	//	return ItemCount;
	//}

	public void Repair()
	{
		floorManager.time += ItemCount * 10;
		ItemCount = 0;
		if (numObject != null)
		{
			Destroy(numObject);
			Destroy(mapObject);
		}
	}

	public void Failure()
	{
		ItemCount = 0;
		if (numObject != null)
		{
			Destroy(numObject);
		}
	}
}
