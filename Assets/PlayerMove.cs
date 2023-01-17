using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float power = 1;
	public float JumpPower = 1;

	Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		var pos = transform.position;

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= power;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += power;
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity += new Vector2(0, JumpPower);
		}

		transform.position = pos;
	}
}
