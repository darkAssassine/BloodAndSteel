using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class WeaponAnimStats : MonoBehaviour
{
    public bool CanDamage;
    public int Damage;

    public bool CanLeftHandDamage;
    public bool CanRightHandDamage;
    public bool CanLeftFootDamage;
    public float ThrowForceMultiplier;
    public float ThrowDamageMultiplier;


    public Action AttackAnimFinished;
    public Action ComboAnimFinished;
    public Action OnThrow;

    public void ComboFinished()
    {
        ComboAnimFinished.Invoke();
    }

    public void Throw()
    {
        OnThrow.Invoke();
    }

    public void AttackAnimationFinished()
    {
        AttackAnimFinished.Invoke();
    }

}
