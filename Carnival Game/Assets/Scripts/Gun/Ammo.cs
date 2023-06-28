using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ammo : MonoBehaviour
{
    #region duckSum
    public delegate void DuckSum();
    public static event DuckSum duckSum;
    #endregion

    public AudioSource LaserSource;

    public float life = 3;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DucksSum();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Glass"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
        LaserSource.Play();
    }

    private void DucksSum()
    {
        duckSum();
    }
}
