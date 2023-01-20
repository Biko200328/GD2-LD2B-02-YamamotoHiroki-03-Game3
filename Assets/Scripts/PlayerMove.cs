using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMove : MonoBehaviour
{
	public float power;
	public float JumpPower;
	public float DropPower;

	public bool isDrop;
	public bool isJump;
	public Rigidbody2D rb;

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

		// 床についてる時のみジャンプ
		if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == true)
		{
			rb.velocity += new Vector2(0, JumpPower);
			isJump = true;
		}

		// ジャンプ中もう一度JumpKeyを押すことでドロップできる
		if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == false && isDrop == false)
		{
			rb.velocity -= new Vector2(0, DropPower);
			isDrop = true;
		}



	}

	private void FixedUpdate()
	{
		if (isDrop) { return; }
		var pos = rb.position;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= power;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += power;
		}
		else
		{
			return;
		}
		rb.position = (pos);
	}
}
