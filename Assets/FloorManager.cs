using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
	public float time;
	public float keepTime;
	public bool isBreak;

	// Start is called before the first frame update
	void Start()
	{
		keepTime = time;
	}

	// Update is called once per frame
	void Update()
	{
		time -= Time.deltaTime;
		if(time < 0)
		{
			isBreak = true;
		}
	}
}
