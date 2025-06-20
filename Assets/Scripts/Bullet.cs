using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    public int damage = 20;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Enemy"))
        {

            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

        Destroy(gameObject);
    }
}
}
