using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_mele : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform melePoint;
    public Transform melePoint2;
    public float meleRange;
    public int attackDamage;
    public Rigidbody2D rb;
    public float hitForce = 3;
    public float attackTime = 0f;
    public float attackRate = 0.5f;
    public Vector2 hitForceV;
    private bool isMele = false;
    public GameObject impactEffect;


    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mele"))
        {
            //Debug.Log("Mele");
            isMele = true;
        }
        else
        {
            isMele = false;
        }
        if (Time.time >= attackTime && !isMele)
        {
            
            //if (!isMele)
                //Debug.Log("can mele");
            if (Input.GetKey(KeyCode.RightControl) || Input.GetButtonDown("Fire1"))
            {   
                //For windows:
                //Mele();
            }
        }
        
        
    }
    public void Mele()
    {
        if (Time.time >= attackTime)
        {
            animator.SetTrigger("Mele");
            Instantiate(impactEffect, melePoint2.position, melePoint2.rotation);
            attackTime = Time.time + 1f / attackRate;
        
            
            Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(melePoint.position, meleRange, enemyLayers);
            foreach(Collider2D enemy in hitEnimies)
            {
                if (enemy.GetComponent<Bullet>())
                {
                    enemy.GetComponent<Bullet>().kill();
                    SoundManager.PlaySound("hit");
                }



                if (enemy.GetComponent<genericBadie>())
                {
                    enemy.GetComponent<genericBadie>().TakeDamage(attackDamage);
                    SoundManager.PlaySound("hit");
                }
                    
                if (enemy.GetComponent<Boss>())
                {
                    SoundManager.PlaySound("hit");
                    enemy.GetComponent<Boss>().TakeDamage(attackDamage);
                }
                    

                //do force
                rb = enemy.GetComponent<Rigidbody2D>();
                if (melePoint.position.x < rb.position.x)
                {
                    rb.velocity = hitForceV;
                }
                else
                {
                    rb.velocity = -hitForceV;
                }              
                    //new Vector2(rb.velocity.x, rb.velocity.y );       



                //Debug.Log("we hit" + enemy.name);

            }

        }
    }
        
}
