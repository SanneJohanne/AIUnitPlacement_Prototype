using UnityEngine;

public class MushroomShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform firePoint; // Empty GameObject as the shooting position
    public float shootInterval = 2f; // Time between shots

    private void Start()
    {
        InvokeRepeating("Shoot", 0f, shootInterval); // Repeats shooting
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Spawn bullet
    }
}
