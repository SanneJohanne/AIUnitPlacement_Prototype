using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 60;
    public int maxHealth = 140;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " HP: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int newHealth)
    {
        health = Mathf.Clamp(newHealth, 0, maxHealth);
    }
}