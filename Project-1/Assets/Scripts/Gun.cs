using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign in Inspector
    public Transform firePoint;         // Where the projectile spawns
    public float projectileSpeed = 20f;
    public float fireRate = 0.2f;       // Time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + fireRate;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Give the projectile forward speed
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }
    }
}
