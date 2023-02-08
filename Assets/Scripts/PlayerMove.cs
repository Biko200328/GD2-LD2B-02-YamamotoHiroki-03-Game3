using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float power;
	public float JumpPower;
	public float DropPower;

	public bool isDrop;
	public Rigidbody2D rb;

	HitBox hitBox;

	public AudioSource jumpSE;

	//public SpriteRenderer spriteRenderer;
	//public Sprite Sprite1;
	//public Sprite Sprite2;
	//public Sprite Sprite3;

	// Start is called before the first frame update
	void Start()
	{
		// Rigidbodyを取得
		rb = gameObject.GetComponent<Rigidbody2D>();

		// 子オブジェクト読み込み
		GameObject child = transform.Find("hitbox").gameObject;
		// class読み込み
		hitBox = child.GetComponent<HitBox>();

		isDrop = false;
	}

	// Update is called once per frame
	void Update()
	{

		// 床についてる時のみジャンプ
		if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == true)
		{
			jumpSE.Play();
			rb.velocity += new Vector2(0, JumpPower);
		}

		// ジャンプ中もう一度JumpKeyを押すことでドロップできる
		if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
		{
			if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == false && isDrop == false)
			{
				rb.velocity -= new Vector2(0, DropPower);
				isDrop = true;
			}
		}

	}

	private void FixedUpdate()
	{
		if (isDrop) { return; }

		var pos = rb.position;
		Vector3 scale = transform.localScale;

		if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
		{
			pos.x -= power;
			scale.x = -2;
		}
		else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
		{
			pos.x += power;
			scale.x = 2;
		}
		else
		{
			return;
		}

		if(pos.x >= 19)
		{
			pos.x = -18.5f;
		}
		if (pos.x <= -19)
		{
			pos.x = 18.5f;
		}

		rb.position = (pos);
		transform.localScale = scale;
	}
}
