using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWithShotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Transform player;
    public static Vector2 enemyScale;
    public Animator anim;
    static public float agroDistance = 2f;
    public GameObject patron;
    void Start()
    {
        enemyScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public static bool hasContact;
    public bool HasConctact()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        return  (agroDistance > distToPlayer) ? true : false;

    }
    // Update is called once per frame
    void Update()
    {
        hasContact = HasConctact();
        if (HasConctact())
        {
            walkToIdle = true;
            reflectToPlayer();
        }
        else
        {
            walkToIdle = false;
            //IdleToShot = false;
            NinjaWalkAI();
        }
        setAnimations();
    }
    public float timeForStep = 3f;
    public float enemySpeed = 5f;
    private bool fuse = true; // needed to fuse reflection when its not be needed
    private bool faceposition = true; //true - right || false - left
    private bool localfaceposition = true; // needed only in NinjaWalkAI function
    void NinjaWalkAI() 
    {
        if (localfaceposition != faceposition) {        //needed by correct reflection to player when 
            transform.localScale *= new Vector2(-1, 1); //when he doese'nt reach to reflect position 
            faceposition = !faceposition;
        }
        if ((int)Time.time % (int)timeForStep != 0) //siple logic for reflecting enemy in N time
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
    public float patronspeed = 0f;
    void reflectToPlayer() // needed by enemy for correct chase to player 
    {
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
    private bool walkToIdle = false;
    private bool walkToDamage = false;
    private bool idleToDamage = false;
    //private bool IdleToShot = false;
    void setAnimations()
    {
        anim.SetBool("walkToIdle", walkToIdle);
        anim.SetBool("walkToDamage", walkToDamage);
        anim.SetBool("idleToDamage", idleToDamage);
        //anim.SetBool("IdleToShot", IdleToShot);
    }

}
