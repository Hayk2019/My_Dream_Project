using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Rigidbody2D rb;
	public Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		Walk();
		Reflect();
		Jump();
		checkingGround();
	}
	public float speed = 2f;
	public Vector2 moveVector;
	void Walk() {
		moveVector.x = Input.GetAxisRaw("Horizontal");
		anim.SetFloat("idleToRun", Mathf.Abs(moveVector.x));
		rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
	}
	public bool faceRight = true;
	void Reflect() {
		if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight)) {
			transform.localScale *= new Vector2(-1, 1);
			faceRight = !faceRight;
		}
	}
	public float JumpForce = 4f;
	void Jump() {
		if (onGround && Input.GetKeyDown(KeyCode.Space)) {
			rb.velocity = new Vector2(rb.velocity.x,JumpForce);
		}
	} 
	public bool onGround;
	public Transform GroundCheck;
	private float checkRadius = 0.5f;
	public LayerMask Ground;
	void checkingGround() {
		onGround = Physics2D.OverlapCircle(GroundCheck.position,checkRadius,Ground);
		//anim.SetBool("onGround", onGround);
	}
}

