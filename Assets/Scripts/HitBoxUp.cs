using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxUp : MonoBehaviour
{
	[SerializeField] GameObject particle;
	GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "material")
		{
			gameManager.PlaybrokeSE();
			Destroy(collision.gameObject);
			Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
			gameManager.AddItemCount();
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "material")
		{
			
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "material")
		{
			
		}
	}
}
