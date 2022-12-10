using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float health;
    public int heartNumber;
    public Image[] hearts;
    public Sprite heartSprite;
    public Animator anim;
    [SerializeField] 
    public  float SwordAttackStrength;
    public static bool attack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private float hurttime;
    public void TakeDamage(float damage) {
        anim.SetBool("hurt", true);
        health -= damage;
    }
    public void attackUP() { attack = false; anim.SetBool("attack", attack); }
    public void attackDown() { attack = true; anim.SetBool("attack", attack); }
    public void SetAttackAnim() {
        anim.SetBool("attack", false);
    }
    public void SetHurtAnim() {
        anim.SetBool("hurt", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (health > heartNumber) {
            health = heartNumber;
        }
        for (int i = 0; i < heartNumber; ++i) {
            if (i < Mathf.RoundToInt(health)) {
                hearts[i].sprite = heartSprite;
            } else {
                hearts[i].color = Color.clear;
            }

        }
    }
}
 