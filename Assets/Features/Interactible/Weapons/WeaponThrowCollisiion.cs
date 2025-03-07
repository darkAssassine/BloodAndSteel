using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowCollisiion : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        { return; }
        if (other.gameObject.CompareTag("Ragdoll"))
        { return; }

        if (!other.transform.CompareTag("Player") && !other.transform.CompareTag("Enemy"))
        {
            weapon.HitSomethingInThrow();
        }
    }
}
