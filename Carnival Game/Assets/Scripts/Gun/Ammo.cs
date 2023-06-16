using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public AudioSource LaserSource;

    public float life = 3;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
        }

        Destroy(gameObject);

        LaserSource.Play();

        
    }
}
