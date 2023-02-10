using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

public class Car : MonoBehaviour
{
	[SerializeField]private float speed;
	[SerializeField] private float speedMin;
	[SerializeField] private float speedMax;
	Rigidbody2D rb;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		speed = (float)Random.Range(1, 5);
		speed = speed / 10;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void FixedUpdate()
	{
		var pos = rb.position;

		pos.x -= speed;

		if (pos.x <= -19)
		{
			Destroy(this.gameObject);
		}

		rb.position = (pos);
	}
}
