using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
	public bool isOn;
	PlayerMove playerMove;
	GameManager gameManager;
	[SerializeField] GameObject particle;

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();

		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// ジャンプリセット
		if(collision.gameObject.tag == "floor" || collision.gameObject.tag == "material")
		{
			isOn = true;
			if (playerMove.isJump == true) playerMove.isJump = false;
		}
		// 床の修復
		if (collision.gameObject.tag == "floor")
		{
			if (playerMove.isDrop == true && gameManager.ItemCount >= 1)
			{
				gameManager.Repair();
				Instantiate(particle, transform.position,Quaternion.identity);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "material")
		{
			isOn = true;
			if (playerMove.isDrop == true) playerMove.isDrop = false;
			if(playerMove.isJump == true) playerMove.isJump = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "material")
		{
			isOn = false;
		}
		//if (collision.gameObject.tag == "material" && playerMove.isJump == true)
		//{
		//	collision.gameObject.transform.Translate(0,-1,0);
		//	//collision.gameObject.SetActive(false);
		//}
	}
}
