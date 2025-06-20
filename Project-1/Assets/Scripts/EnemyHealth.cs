using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Floating Damage Number")]
    public GameObject damageNumberPrefab; // Assign in Inspector
    public Transform damageNumberSpawnPoint; // Assign a point above the enemy's head

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Spawn floating damage number safely
        if (damageNumberPrefab != null && damageNumberSpawnPoint != null)
        {
            GameObject dmgNumber = Instantiate(damageNumberPrefab, damageNumberSpawnPoint.position, Quaternion.identity);
            FloatingDamageNumber floatScript = dmgNumber.GetComponent<FloatingDamageNumber>();

            if (floatScript != null)
            {
                floatScript.SetDamage((int)amount);
            }
            else
            {
                Debug.LogWarning("FloatingDamageNumber component missing on damage number prefab!");
            }
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
