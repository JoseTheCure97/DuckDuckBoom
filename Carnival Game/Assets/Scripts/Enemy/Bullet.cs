using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region damage
    public delegate void Damage(int damage);
    public static event Damage damage;

    [SerializeField] private int damageAmount;
    #endregion

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damage != null)
            {
                GivenDamage();
                Destroy(this.gameObject);
            }
        }

        Destroy(gameObject);
    }

    private void GivenDamage()
    {
        damage(damageAmount);
    }
}
