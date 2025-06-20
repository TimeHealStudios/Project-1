using System.Collections;
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
    public float reloadTime = 1.5f;

    [Header("Ammo")]
    private int currentAmmo;
    private float nextFireTime = 0f;
    private bool isReloading = false;

    [Header("UI")]
    private WeaponUI weaponUI;

    void Start()
    {
        currentAmmo = magSize;
        UpdateUI();
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        bool canShoot = Time.time >= nextFireTime;

        if (fireMode == FireMode.FullAuto && Input.GetMouseButton(0) && canShoot)
        {
            Fire();
        }
        else if (fireMode == FireMode.SemiAuto && Input.GetMouseButtonDown(0) && canShoot)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magSize)
        {
            StartCoroutine(Reload());
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

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        // Optional: play reload animation or sound here

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magSize;
        isReloading = false;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (weaponUI != null)
        {
            weaponUI.UpdateWeaponUI(gameObject.name.Replace("(Clone)", ""), currentAmmo, magSize);
        }
    }

    public void SetWeaponUI(WeaponUI ui)
    {
        weaponUI = ui;
        UpdateUI();
    }
}
