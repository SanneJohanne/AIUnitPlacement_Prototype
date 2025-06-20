using UnityEngine;

public class PineappleScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int damage = 10;
    private float damageCooldown = 1f;
    private float nextDamageTime = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            ItemHealth itemHealth = collision.gameObject.GetComponent<ItemHealth>();

            if (itemHealth != null && Time.time >= nextDamageTime)
            {
                itemHealth.TakeDamage(damage);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}