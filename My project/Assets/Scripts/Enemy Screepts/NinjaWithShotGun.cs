using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWithShotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NinjaWalkAI();
    }
    public float timeForStep = 3f;
    public float enemySpeed = 5f;
    private bool conton = true;
    void NinjaWalkAI() {
        if ((int)Time.time % (int)timeForStep != 0)
        {
            conton = true;
        }
        else if (conton == true)
        {
            conton = false;
            transform.localScale *= new Vector2(-1, 1);
            enemySpeed = -enemySpeed;
        }
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
    }
}
