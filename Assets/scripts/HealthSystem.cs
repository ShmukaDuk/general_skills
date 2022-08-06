using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public bool invincable = false;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

   
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }   

    public void TakeDamage(int damageAmmount)
    {
        if(!invincable)
        {
            SoundManager.PlaySound("playerHit");
            currentHealth -= damageAmmount;
            healthBar.setHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GlobalVariables.isFightingBoss = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        

    }




}
