using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	SceneController sceneController;

	int resultScore;

	public Text text;

	// Start is called before the first frame update
	void Start()
	{
		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		resultScore = GameManager.score;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			sceneController.sceneChange("TitleScene");
		}

		text.text = "Score : " + resultScore;
	}
}
