using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class floor : MonoBehaviour
{
	FloorManager floorManager;
	public SpriteRenderer spriteRenderer;
	public Sprite Sprite1;
	public Sprite Sprite2;
	public Sprite Sprite3;

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
			spriteRenderer.sprite = Sprite3;
		}
		else if (floorManager.time <= floorManager.keepTime / 2)
		{
			spriteRenderer.sprite = Sprite2;
		}
		else
		{
			spriteRenderer.sprite = Sprite1;
		}
	}
}
