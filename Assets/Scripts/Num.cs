using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
	GameObject player;
	Rigidbody2D rb;
	Rigidbody2D playerRb;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		playerRb = player.GetComponent<Rigidbody2D>();

		// Rigidbody‚ðŽæ“¾
		rb = gameObject.GetComponent<Rigidbody2D>();
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		var n =playerRb.position - rb.position;

		n = n.normalized;

		rb.position += n * 0.15f;
	}
}
