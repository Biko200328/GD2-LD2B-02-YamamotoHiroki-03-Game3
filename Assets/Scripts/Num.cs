using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
	GameObject player;
	private Vector3 offset;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		transform.position = player.transform.position;
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	

	void LateUpdate()
	{
		transform.position = Vector2.Lerp(transform.position, player.transform.position + offset, 6.0f * Time.deltaTime);
	}
}
