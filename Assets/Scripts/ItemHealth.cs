using UnityEngine;

public class ItemHealth : MonoBehaviour
{

    public int health = 100;
    public int damagePerSecond = 10;

    public void TakeDamage(float damage)
    {
        health -= Mathf.RoundToInt(damagePerSecond);
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

}
