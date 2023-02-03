using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HitBox : MonoBehaviour
{
	public bool isOn;
	PlayerMove playerMove;
	GameManager gameManager;
	[SerializeField] GameObject particle;

	[SerializeField] GameObject good;
	[SerializeField] GameObject excellent;
	[SerializeField] float time = 1;
	float keepTime;
	bool isJudge;
	int itemCount;

	Vector3 pos;

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();

		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();

		keepTime = time;
	}

	// Update is called once per frame
	void Update()
	{
		if(isJudge == true)
		{
			time -= Time.deltaTime;
			if(time <= 0)
			{
				isJudge = false;
				time = keepTime;
				good.SetActive(false);
				excellent.SetActive(false);
			}
		}

		if(isJudge)
		{
			if (itemCount >= 20)
			{
				excellent.SetActive(true);
			}
			else if (itemCount >= 10)
			{
				good.SetActive(true);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// ƒWƒƒƒ“ƒvƒŠƒZƒbƒg
		if(collision.gameObject.tag == "floor" || collision.gameObject.tag == "material")
		{
			isOn = true;
		}
		if(playerMove.isDrop == true)
		{
			// °‚ÌC•œ
			if (collision.gameObject.tag == "floor" && gameManager.ItemCount >= 1)
			{
				itemCount = gameManager.ItemCount;
				pos = transform.position;
				gameManager.Repair();
				gameManager.CreateMap();
				if (isJudge == false)isJudge = true;
				Instantiate(particle, transform.position, Quaternion.identity);
			}
			if (collision.gameObject.tag == "material" && gameManager.ItemCount >= 1)
			{
				gameManager.Failure();
			}
			// ŽÔ‚ð”j‰ó
			else if(collision.gameObject.tag == "car")
			{
				gameManager.Failure();
				Destroy(collision.gameObject);
			}
		}
		//// °‚ÌC•œ
		//if (collision.gameObject.tag == "floor")
		//{
		//	if (playerMove.isDrop == true && gameManager.ItemCount >= 1)
		//	{
		//		gameManager.Repair();
		//		Instantiate(particle, transform.position,Quaternion.identity);
		//	}
		//}
		//// ŽÔ‚Æ‚Ì“–‚½‚è”»’è
		//if(collision.gameObject.tag == "car")
		//{
		//	if (playerMove.isDrop == true)
		//	{
		//		gameManager.Failure();
		//		Destroy(collision.gameObject);
		//	}
		//}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "material")
		{
			isOn = true;
			if (playerMove.isDrop == true) playerMove.isDrop = false;
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
