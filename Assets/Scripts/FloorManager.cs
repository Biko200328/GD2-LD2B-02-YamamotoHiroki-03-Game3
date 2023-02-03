using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
	public float time;
	public float keepTime;
	public bool isBreak;
	public GameObject floor;
	public Text text;
	public bool isEnd;

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
			isEnd = true;
			Destroy(floor);
		}
		text.text = "‘Ï‹v’l(Žc‚èŽžŠÔ) : " + time;
	}
}
