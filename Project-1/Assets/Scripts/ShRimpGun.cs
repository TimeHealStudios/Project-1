using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShRimpGun : MonoBehaviour
{
        
    public GameObject bulletPrefab;       // Reference to the bullet prefab
    public Transform firePoint;           // Point where the bullet originates (the damn gun brodin)      

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button or Ctrl
        {
            FireBullet();
        }
    }
      void FireBullet()
    {
        // Instantiate bullet at firePoint position and facing same direction
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Make sure bullet has a Rigidbody and apply velocity
    }
}
