using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxUp : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "material")
		{
			Destroy(collision.gameObject);
			//collision.gameObject.SetActive(false);
			//if(playerMove.isDrop == true)playerMove.isDrop = false;
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
