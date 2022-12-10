using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Rigidbody2D rb;
	public float Healt;
	public Animator anim;
	public GameObject sword;
	private bool onGround;
	public Transform GroundCheck;
	private float checkRadius = 0.5f;
	public LayerMask Ground;
	public float speed = 0f;
	private float normalspeed = 0f;
	private bool faceRight = true;
	// Start is called before the first frame update
	void Start()
	{
		normalspeed = 0f;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		Walk();
		checkingGround();
	}
	
	void Walk()
	{
		rb.velocity = new Vector2(normalspeed, rb.velocity.y);
		anim.SetFloat("idleToRun", Mathf.Abs(rb.velocity.x));
		if ((rb.velocity.x > 0 && !faceRight) || (rb.velocity.x < 0 && faceRight))
		{
			transform.localScale *= new Vector2(-1, 1);
			faceRight = !faceRight;
		}
	}
	public void WalktUP() {
		normalspeed = 0f;
	}
	public void WalkRightDown() {
		
		normalspeed = speed;
	}
	
	public void WalkleftDown()
	{
		
		normalspeed = -speed;
	}
		
	public float JumpForce = 4f;
	public void Jump() {
		if (onGround) {
			rb.velocity = new Vector2(rb.velocity.x,JumpForce);
		}
	} 
	void checkingGround() {
		onGround = Physics2D.OverlapCircle(GroundCheck.position,checkRadius,Ground);
	}
	public  bool attack = false;
}

