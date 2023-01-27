using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Car : MonoBehaviour
{
	[SerializeField] private float speed;
	Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void FixedUpdate()
	{
		var pos = rb.position;

		pos.x -= speed;

		if (pos.x >= 19)
		{
			pos.x = -18.5f;
		}
		if (pos.x <= -19)
		{
			pos.x = 18.5f;
		}

		rb.position = (pos);
	}
}
