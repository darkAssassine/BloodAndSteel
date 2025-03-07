using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(AttackEvents))]
public class PlayerWeaponSlot : MonoBehaviour
{
    bool canThrow = false;

    [SerializeField]
    private Weapon startWeapon;

    [SerializeField]
    private Transform weaponHand;

    [SerializeField]
    private float unarmedKnockback;

    [SerializeField]
    private float timeUnilInputGetDeleted;

    [SerializeField]
    private float timeToPressTillHeavyAttack;

    [SerializeField]
    private Animator anim;

    [SerializeField] 
    private Animator kickAnim;

    [SerializeField]
    private WeaponAnimStats stats;

    [SerializeField]
    private float kickCooldown;

    [SerializeField]
    private ParticleSystem throwIdleVFX;

    private PlayerInputs input;
    private Weapon currentWeapon;

    private WeaponType currentWeaponType;

    private bool canKick;
    private float attackPressedTime;

    private float attackPressedCount;

    private float throwDamageMulti;
    private float throwForceMulti;
    public bool isAttacking;

    void Start()
    {
        canKick = true;
        input = GetComponent<PlayerInputs>();
        if (startWeapon != null)
        {
        }
        else
            startWeapon = null;
        stats.AttackAnimFinished += AttackAnimFinished;
        stats.ComboAnimFinished += ComboEnded;
        stats.OnThrow += Throw;
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (anim.GetBool("ShouldAttack") == false)
        {
            if (weapon.Equip(weaponHand, stats, transform.tag))
            {
                if (currentWeapon != null)
                {
                    currentWeapon.UnEquip();
                }
                currentWeapon = weapon;
                SetCurrentWeaponType(true);
            }
        }
    }

    private void Update()
    {
        TryThrow();

      
            LightAttack();

   
        TryKick();


        if (anim.GetBool("ShouldAttack") == false)
            stats.CanDamage = false;

        isAttacking = anim.GetBool("ShouldAttack");

    }

    private void LightAttack()
    {
        if (attackPressedCount > 0)
            anim.SetBool("ShouldAttack", true);
        else
            anim.SetBool("ShouldAttack", false);

        if (!input.Attack)
            return;

        ++attackPressedCount;

    }

    private void SetCurrentWeaponType(bool shouldPlay)
    {
        if (currentWeapon != null)
        {
            currentWeaponType = currentWeapon.WeaponType;
            if (shouldPlay)
            {
                switch (currentWeaponType)
                {
                    case WeaponType.OneHanded:
                        anim.Play("one_handed_movement");
                        break;

                    case WeaponType.TwoHanded:
                        anim.Play("one_handed_movement");
                        break;

                    case WeaponType.Speers:
                        anim.Play("one_handed_movement");
                        break;

                    case WeaponType.None:
                        anim.Play("movement");
                        break;
                }
            }
        }
    }

    private void AttackAnimFinished()
    {
        --attackPressedCount;
    }

    private void ComboEnded()
    {
        attackPressedCount = 0;
    }

    private void TryThrow()
    {
        if (input.Throw)
        {
            anim.SetBool("ChargeThrow", true);
            anim.SetBool("Throw", false);
            canThrow = true;
        }

        if (canThrow && input.Throw == false)
        {
            throwDamageMulti = stats.ThrowDamageMultiplier;
            throwForceMulti = stats.ThrowForceMultiplier;
            anim.SetBool("ChargeThrow", false);
            anim.SetBool("Throw", true);
            canThrow = false;
        }
    }

    private void Throw()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Throw(transform, throwDamageMulti, throwForceMulti);
            currentWeapon = null;
        }
        throwIdleVFX.Stop();
        throwDamageMulti = 1;
        throwForceMulti = 1;
        SetCurrentWeaponType(false);
    }

    private void TryKick()
    {
        if (input.Kick && isAttacking == false && canKick)
        {
            kickAnim.Play("spartan_kick", -1, 0);
            canKick = false;
            StartCoroutine(StartKickCooldown());
            if (currentWeapon == null)
                anim.Play("spartan_kick_unarmed");
            else
                anim.Play("spartan_kick_weapon");
        }
    }

    private IEnumerator StartKickCooldown()
    {
        yield return new WaitForSeconds(kickCooldown);
        canKick = true;
    }
}





// --------------if we want a heavy attack again-------------------


//private void HeavyAttack()
//{
//    attackEvents.OnHeavyAttack.Invoke();
//}

//attackPressedTime += Time.deltaTime;


//if (!input.Attack && attackPressedTime > 0)
//{
//    if (attackPressedTime < timeToPressTillHeavyAttack)
//        LightAttack();
//    else
//        LightAttack();
//        //HeavyAttack();
//    attackPressedTime = 0;
//}
