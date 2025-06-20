using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public int maxEnemies = 3;
    private int enemyCount = 0;

    public GameObject gameOverUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCount++;
            Debug.Log("Enemy entered! Count: " + enemyCount);

            if (enemyCount >= maxEnemies)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Too many enemies entered.");
        
        gameOverUI.SetActive(true);
    }
}
