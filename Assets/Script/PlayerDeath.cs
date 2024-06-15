using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    public int health = 3; // Player's health
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>(); // Find the UIManager in the scene
        uiManager.UpdateHealthText(health); // Update initial health
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        uiManager.UpdateHealthText(health); // Update health display

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {        
        GameManager.instance.GameOver();
        Destroy(gameObject);
    }
}
