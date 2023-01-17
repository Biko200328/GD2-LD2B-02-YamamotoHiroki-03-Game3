using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float power;
	public float JumpPower;
	public float DropPower;

	public bool isDrop;

	Rigidbody2D rb;

	HitBox hitBox;

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
		var pos = transform.position;

		// x軸移動
		// ドロップしていない間は移動できる
		if(isDrop == false)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				pos.x -= power;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				pos.x += power;
			}
		}

		// 床についてる時のみジャンプ
		if(Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == true)
		{
			rb.velocity += new Vector2(0, JumpPower);
		}

		// ジャンプ中もう一度JumpKeyを押すことでドロップできる
		if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == false && isDrop == false)
		{
			rb.velocity -= new Vector2(0, DropPower);
			isDrop = true;
		}


		transform.position = pos;
	}
}
