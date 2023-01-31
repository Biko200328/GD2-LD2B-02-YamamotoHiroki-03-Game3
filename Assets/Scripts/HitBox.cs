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
				gameManager.Repair();
				Instantiate(particle, transform.position, Quaternion.identity);
			}
			// ŽÔ‚ð”j‰ó
			else if(collision.gameObject.tag == "car")
			{
				if (playerMove.isDrop == true)
				{
					gameManager.Failure();
					Destroy(collision.gameObject);
				}
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
