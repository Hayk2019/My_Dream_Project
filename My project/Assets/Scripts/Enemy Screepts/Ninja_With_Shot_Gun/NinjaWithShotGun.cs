using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWithShotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Transform player;
    public float agroDistance = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (agroDistance > distToPlayer)
        {
            startFightWithPlayer();
            reflectToPlayer();
        }
        else
        {
            NinjaWalkAI();
        }
    }
    public float timeForStep = 3f;
    public float enemySpeed = 5f;
    private bool fuse = true;
    private bool faceposition = true; //true - right || false - left
    private bool localfaceposition = true;
    void NinjaWalkAI() {
        /*if (localfaceposition != faceposition) {
            transform.localScale *= new Vector2(-1, 1);
            faceposition = !faceposition;
        }*/
        if ((int)Time.time % (int)timeForStep != 0)
        {
            fuse = true;    
        }
        else if (fuse == true)
        {
            fuse = false;
            transform.localScale *= new Vector2(-1, 1);
            enemySpeed = -enemySpeed;
        }
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
    }
    void startFightWithPlayer() {
        Debug.Log("Tesav");
    }
    void reflectToPlayer() {
        if ((player.position.x > transform.position.x) && (transform.localScale.x < 0)) {
            transform.localScale *= new Vector2(-1, 1);
            faceposition = !faceposition;
            return;
        }
        if ((player.position.x < transform.position.x) && (transform.localScale.x > 0)) {
            transform.localScale *= new Vector2(-1, 1);
            faceposition = !faceposition;
            return;
        }
    }
}
