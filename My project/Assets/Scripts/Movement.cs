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
    // Update is called once per frame
    void Update()
    {
        Walk();
        Reflect();
    }
}
