using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class floor : MonoBehaviour
{
	FloorManager floorManager;
	public TilemapRenderer renderer1;
	public TilemapRenderer renderer2;
	public TilemapRenderer renderer3;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		floorManager = gameManager.GetComponent<FloorManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (floorManager.time <= floorManager.keepTime / 4)
		{
			this.gameObject.GetComponent<TilemapRenderer>().material = renderer1.material;
		}
		else if (floorManager.time <= floorManager.keepTime / 2)
		{

		}
		else
		{

		}
	}
}
