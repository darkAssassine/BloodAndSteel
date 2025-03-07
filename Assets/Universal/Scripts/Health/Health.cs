using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Header("Health")]
    private int maxHp;

    [SerializeField]
    private float recoverTime;

    private int currentHp;
    private float currentRecoverTime;

    private HealthEvent healthEvent;
    private Rigidbody rb;

    [HideInInspector]
    public bool CanTakeDamage = true;
    private bool isAlive = true;

    public int MaxHp { get; private set; }
    public int CurrentHp { get; private set; }
   
    void Awake()
    {
        healthEvent = GetComponent<HealthEvent>();
        rb = GetComponent<Rigidbody>();

        currentHp = maxHp;

        currentRecoverTime = 0;
        MaxHp = maxHp;
    }

    private void Update()
    {
        CurrentHp = currentHp;
        currentRecoverTime -= Time.deltaTime;
    }

    public void SetMaxHealth(int maxHealth)
    {
        maxHp = maxHealth;
        MaxHp = maxHp;

    }


    public bool TakeDamage(int damage)
    {
        if (currentRecoverTime < 0 && CanTakeDamage)
        {
            currentRecoverTime = recoverTime;
            currentHp -= damage;

            if (healthEvent != null)
                healthEvent.OnHit.Invoke();

            if (currentHp <= 0)
                Death();
            return true;
        }
        return false;
    }


    public bool TakeDamage(int damage, Vector3 direction, float force)
    {
        if (currentRecoverTime < 0 && CanTakeDamage)
        {
            currentRecoverTime = recoverTime;
            currentHp -= damage;
            if (healthEvent != null)
                healthEvent.OnHit.Invoke();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
            if (currentHp <= 0)
                Death();
            return true;
        }
        return false;

    }

    public bool GetKicked(int damage, Vector3 direction, float force)
    {
        if (currentRecoverTime < 0 && CanTakeDamage)
        {
            currentRecoverTime = recoverTime;
            currentHp -= damage;
            if (healthEvent.OnKick != null)
                healthEvent.OnKick.Invoke();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
            if (currentHp <= 0)
                Death();
            return true;
        }
        return false;
    }

public void Heal(int healAmoung)
    {
        currentHp += healAmoung;
        if (currentHp > maxHp)
            currentHp = maxHp;
        if (healthEvent != null)
            healthEvent.OnHeal.Invoke();

    }

    public void Death()
    {
        if (isAlive == false)
            return;
        currentHp = 0;
        isAlive = false;
        if (healthEvent != null)
        {
            healthEvent.OnDeath.Invoke();
        }
            
    }
}
