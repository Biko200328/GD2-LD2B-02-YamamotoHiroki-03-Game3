using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float power = 1;
	public float JumpPower = 1;

	Rigidbody2D rb;

	HitBox hitBox;

	// Start is called before the first frame update
	void Start()
	{
		// Rigidbody���擾
		rb = gameObject.GetComponent<Rigidbody2D>();

		// �q�I�u�W�F�N�g�ǂݍ���
		GameObject child = transform.Find("hitbox").gameObject;
		// class�ǂݍ���
		hitBox = child.GetComponent<HitBox>();
	}

	// Update is called once per frame
	void Update()
	{
		var pos = transform.position;

		//x���ړ�
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= power;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += power;
		}

		//���ɂ��Ă鎞�̂݃W�����v
		if(Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == true)
		{
			rb.velocity += new Vector2(0, JumpPower);
		}

		transform.position = pos;
	}
}
