using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	[SerializeField] GameObject carPrefab;
	[SerializeField] float timer;
	float keeptimer;
	bool isCreate;
	

	// Start is called before the first frame update
	void Start()
	{
		keeptimer = timer;
	}

	// Update is called once per frame
	void Update()
	{
		if(isCreate == false)timer -= Time.deltaTime;

		if(timer <= 0)
		{
			isCreate = true;
		}
		if(isCreate == true)
		{
			Instantiate(carPrefab, transform.position, Quaternion.identity);
			timer = keeptimer;
			isCreate = false;
		}
	}
}
