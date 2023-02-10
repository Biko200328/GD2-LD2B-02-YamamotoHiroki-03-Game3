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

	[SerializeField] float timer;
	bool isCanMove;


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
