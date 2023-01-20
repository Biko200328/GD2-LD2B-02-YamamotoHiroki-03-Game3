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
		// Rigidbody���擾
		rb = gameObject.GetComponent<Rigidbody2D>();

		// �q�I�u�W�F�N�g�ǂݍ���
		GameObject child = transform.Find("hitbox").gameObject;
		// class�ǂݍ���
		hitBox = child.GetComponent<HitBox>();

		isDrop = false;
	}

	// Update is called once per frame
	void Update()
	{

		// ���ɂ��Ă鎞�̂݃W�����v
		if (Input.GetKeyDown(KeyCode.Space) && hitBox.isOn == true)
		{
			rb.velocity += new Vector2(0, JumpPower);
			isJump = true;
		}

		// �W�����v��������xJumpKey���������ƂŃh���b�v�ł���
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
