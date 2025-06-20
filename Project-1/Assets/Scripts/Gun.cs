using UnityEngine;

public enum FireMode { SemiAuto, FullAuto }

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public GameObject projectilePrefab;      // Assign in Inspector
    public Transform firePoint;              // Where the projectile spawns
    public float projectileSpeed = 20f;
    public float fireRate = 0.2f;            // Time between shots
    public int magSize = 15;                 // Magazine capacity
    public float damage = 25f;               // Damage per bullet
    public FireMode fireMode = FireMode.SemiAuto;

    [Header("Ammo")]
    public int currentAmmo;

    [Header("UI")]
    public WeaponUI weaponUI;  // Assign in Inspector or dynamically

    private float nextFireTime = 0f;

    void Start()
    {
        currentAmmo = magSize;  // Start with full mag
        UpdateUI();
    }

    void Update()
    {
        if (currentAmmo <= 0)
        {
            // TODO: trigger reload here or block firing
            return;
        }

        bool canShoot = Time.time >= nextFireTime;

        if (fireMode == FireMode.FullAuto)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                Fire();
            }
        }
        else // SemiAuto
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                Fire();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + fireRate;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }

        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = damage;
        }

        currentAmmo--;
        UpdateUI();
    }

    public void Reload()
    {
        currentAmmo = magSize;
        UpdateUI();
        // TODO: reload animations/sounds
    }

    void UpdateUI()
    {
        if (weaponUI != null)
        {
            weaponUI.UpdateWeaponUI(gameObject.name, currentAmmo, magSize);
        }
    }
}
