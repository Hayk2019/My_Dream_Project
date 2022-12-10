using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNinja : MonoBehaviour
{
    public float health;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void checkHealthing() {
        if (health <= 0 && (null != gameObject))
        {
            anim.SetBool("death", true);
           
        }
        
    }
    public void setDamageOff()
    {
        anim.SetBool("hurt", false);
    }
    public void setDeathOff()
    {
        anim.SetBool("death", false);
        Destroy(gameObject);
    }
    public void TakeDamage(float Damage) {
        anim.SetBool("hurt",true);
        health -= Damage;
    }
    // Update is called once per frame
    void Update()
    {
        checkHealthing();
        Debug.Log(health);

    }
}
