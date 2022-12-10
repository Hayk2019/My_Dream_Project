using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float tbwAttack;
    private float tbwAttack_;
    public LayerMask enemy;
    public float damage;
    public float attackRadus;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (tbwAttack_ <= 0)
        {
            if (Player.attack) 
            { 
                Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadus, enemy);
                for (int i = 0; i < enemies.Length; ++i)
                {
                    if (enemies[i] != null)
                    {
                        EnemyNinja temp =enemies[i].GetComponent<EnemyNinja>();
                        if (temp != null) {
                            temp.TakeDamage(damage);
                        }
                    }
                }
            } 
            tbwAttack_ = tbwAttack;
        }
        else {
            tbwAttack_ -= Time.deltaTime;

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadus);
    }
}
