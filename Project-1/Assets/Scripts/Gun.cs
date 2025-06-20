using UnityEngine;

public enum FireMode { SemiAuto, FullAuto }

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float fireRate = 0.2f;
    public int magSize = 15;
    public float damage = 25f;
    public FireMode fireMode = FireMode.SemiAuto;

    [Header("Ammo")]
    private int currentAmmo;
    private float nextFireTime = 0f;

    [Header("UI")]
    private WeaponUI weaponUI;

    void Start()
    {
        currentAmmo = magSize;
        UpdateUI();
    }

    void Update()
    {
        if (currentAmmo <= 0)
            return;

        bool canShoot = Time.time >= nextFireTime;

        if (fireMode == FireMode.FullAuto && Input.GetMouseButton(0) && canShoot)
        {
            Fire();
        }
        else if (fireMode == FireMode.SemiAuto && Input.GetMouseButtonDown(0) && canShoot)
        {
            Fire();
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
        // Add animation/sound here if needed
    }

    void UpdateUI()
    {
        if (weaponUI != null)
        {
            weaponUI.UpdateWeaponUI(gameObject.name, currentAmmo, magSize);
        }
    }

    // Call this after instantiating the weapon
    public void SetWeaponUI(WeaponUI ui)
    {
        weaponUI = ui;
        UpdateUI();
    }
}
