using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    public Image healthBar;

    private bool isDead;

    public GameManagerScript gameManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
      
    }

    public void TakeDamage(int amount) //Pour quand un autre script apelle cette fontion , amount pour par exemple différentes attaques
    {
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / 10f;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
        }
    }
}