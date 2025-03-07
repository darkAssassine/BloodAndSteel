using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerLimbs : MonoBehaviour
{
    public enum Limp
    {
        HandR = 0,
        HandL= 5,
        FootL = 10, 
    }


    [SerializeField]
    private Limp currentLimp;

    [SerializeField]
    private WeaponAnimStats stats;

    [SerializeField]
    private string immuneTag;

    [SerializeField]
    private float knockBack;

    [SerializeField]
    private int damage = 20;

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
        { return; } 
        if (currentLimp == Limp.HandL)
        {
            if (stats.CanLeftHandDamage && other.GetComponent<Health>())
            {
                if (!other.CompareTag(immuneTag))
                {
                    if (other.GetComponent<Health>().TakeDamage(damage, Player.Direction, knockBack))
                    {
                        //Destroy(Instantiate(hitSpark, hitSparkTrans.position, hitSparkTrans.rotation, hitSparkTrans), 2);
                    }
                }
            }
        }
        else if (currentLimp == Limp.HandR)
        {
            if (stats.CanRightHandDamage && other.GetComponent<Health>())
            {
                if (!other.CompareTag(immuneTag))
                {
                    if (other.GetComponent<Health>().TakeDamage(damage, Player.Direction, knockBack))
                    {
                        //Destroy(Instantiate(hitSpark, hitSparkTrans.position, hitSparkTrans.rotation, hitSparkTrans), 2);
                    }
                }
            }
        }
        else if (currentLimp == Limp.FootL)
        {
            if (stats.CanLeftFootDamage && other.GetComponent<Health>())
            {
                if (!other.CompareTag(immuneTag))
                {
                    if (other.GetComponent<Health>().GetKicked(damage, Player.Direction, knockBack))
                    {
                        //Destroy(Instantiate(hitSpark, hitSparkTrans.position, hitSparkTrans.rotation, hitSparkTrans), 2);
                    }
                }
            }
        }
    }

}

