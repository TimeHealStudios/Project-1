using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float fireRate = 0.2f;
    public float reloadTime = 1.5f;
    public int magSize = 15;

    private int currentAmmo;
    private float nextFireTime = 0f;
    private bool isReloading = false;

    private WeaponUI weaponUI;

    void Start()
    {
        currentAmmo = magSize;
        weaponUI = FindObjectOfType<WeaponUI>();
        UpdateUI();
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magSize)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            if (currentAmmo > 0)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    void Fire()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        currentAmmo--;
        UpdateUI();
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magSize;
        isReloading = false;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (weaponUI != null)
        {
            weaponUI.UpdateWeaponUI("Rifle", currentAmmo, magSize);
        }
    }
}
