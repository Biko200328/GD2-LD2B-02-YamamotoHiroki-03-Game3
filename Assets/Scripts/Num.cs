using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
	GameObject player;
	private Vector3 offset;

	GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		transform.position = player.transform.position;
		offset = transform.position - player.transform.position;

		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if(gameManager.ItemCount <= 0)
		{
			Destroy(this.gameObject);
			gameManager.isCreate = false;
		}
	}
	

	void LateUpdate()
	{
		transform.position = Vector2.Lerp(transform.position, player.transform.position + offset, 6.0f * Time.deltaTime);
	}
}