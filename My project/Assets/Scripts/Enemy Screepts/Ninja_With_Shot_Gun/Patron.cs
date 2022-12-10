using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    public Transform playerPosition;
    public float patronLifetime;
    private float patronLifetime_;
    public float damage;
    public float speed;
    public float distance;
    private Vector2 patronRay;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        patronLifetime_ = patronLifetime;
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        transform.localScale = new Vector2(Mathf.Abs(transform.position.x - playerPosition.position.x)/ (transform.position.x - playerPosition.position.x), transform.localScale.y);
        patronRay = new Vector2(-transform.localScale.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(patronRay * speed * Time.deltaTime);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, patronRay, distance, whatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<Player>().TakeDamage(damage);
                if (null != gameObject)
                {
                    Destroy(gameObject);
                }
            }
        }
        if (patronLifetime_ <= 0)
        {
            Destroy(gameObject);
        }
        else {
            patronLifetime_ -= Time.deltaTime;
        }
    }
}
