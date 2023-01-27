using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
	SceneController sceneController;

	// Start is called before the first frame update
	void Start()
	{
		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			sceneController.sceneChange("GameScene");
		}
	}
}
