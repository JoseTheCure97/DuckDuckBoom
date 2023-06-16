using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{


    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    AudioSource m_ShootingSound;

    void Start()
    {
        m_ShootingSound = GetComponent<AudioSource>(); 
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_ShootingSound.Play();

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }



}
