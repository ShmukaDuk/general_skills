using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Slider slider;

    public bool isEnv= false;
    public int enRagedHP = 200;
    public int health = 100;
    public GameObject deathEffect;
    public bool isEnraged = false;
    public Animator anim;
    public void TakeDamage(int damage)
    {
        if (!isEnv)
        {
            health -= damage;
            setHealth(health);
        }
        
        if (health <= 0 && !isEnraged)
        {
            health = enRagedHP;
            isEnraged = true;
            anim.SetBool("isEnraged", true);
            setMaxHealth(enRagedHP);


            Debug.Log("Enraged");
        }
        if (health <= 0 && isEnraged)
        {
            Die();
        }
        
    }

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void setHealth(int health)
    {
        slider.value = health;
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetBool("die", true);

    }
    public void Destroy()
    {
        GlobalVariables.levelComplete = true;
        Destroy(gameObject);
        //Debug.Log("gg");

    }
    public void Start()
    {
        setMaxHealth(health);
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject obj in otherObjects)
        {
            Debug.Log("Found a gameobject tagged ground");
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in otherObjects)
        {
            Debug.Log("Found a player object");
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }



    }
    



// Start is called before the first frame update
public Transform player;
    public bool isFlipped = false;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
