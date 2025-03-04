using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
       public GameObject bulletPrefab;
       public Transform firePointRotation;
       public Transform bulletSpawnPoint;
       public float bulletSpeed = 20f;
       public int damage = 5;
       public Transform triggersRotation;


    void Update()
    {
        if (UIManager.isPaused)
            return;
        RotateBulletSpawnPointTowardsMouse();
        RotatePickupTrigger();
        if (Input.GetButtonDown("Fire1"))
        {
        }
    }
    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector2 direction  = (mousePosition - firePointRotation.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0 ,angle));
    }
    void RotatePickupTrigger()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector2 direction  = (mousePosition - triggersRotation.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        triggersRotation.rotation = Quaternion.Euler(new Vector3(0, 0 ,angle));
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        bullet.GetComponent<BulletScript>().damage = damage;

        Destroy(bullet, 1f);
    }
}
