using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 25f;
    public float speed = 20f;
    public float lifeTime = 3f;

    // Optional: assign this in Inspector to filter collisions only with enemies
    public LayerMask enemyLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.useGravity = false;
            rb.linearVelocity = transform.forward * speed;  
        }

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Optional layer check � uncomment if you want to use it
        // if (((1 << other.gameObject.layer) & enemyLayer) == 0) return;

        TryDealDamage(other);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        TryDealDamage(collision.collider);
        Destroy(gameObject);
    }

    void TryDealDamage(Component hitTarget)
    {
        EnemyHealth enemy = hitTarget.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        // else could log or ignore
    }
}
