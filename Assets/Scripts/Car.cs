using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Car : MonoBehaviour
{
	[SerializeField] private float speed;
	Rigidbody2D rb;

	[SerializeField] float timer;
	bool isCanMove;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;
		if(timer <= 0)
		{
			isCanMove = true;
		}
	}

	private void FixedUpdate()
	{
		if (isCanMove == false) { return; }

		var pos = rb.position;

		pos.x -= speed;

		if (pos.x <= -19)
		{
			Destroy(this.gameObject);
		}

		rb.position = (pos);
	}
}
