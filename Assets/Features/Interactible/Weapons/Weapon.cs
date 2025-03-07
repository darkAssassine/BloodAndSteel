using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : Interactible
{
    [SerializeField]
    private WeaponType weaponType;

    [SerializeField]
    private int throwDamage;

    [SerializeField]
    private float knockBack;

    [SerializeField]
    private float throwForce;

    [SerializeField]
    private float rotationSpeed;

    private string immuneTag;

    [SerializeField]
    private GameObject hitSpark;

    [SerializeField]
    private float DespawnTimeAfterBeingDropped;

    [SerializeField]
    private Transform hitSparkTrans;

    [SerializeField]
    private GameObject weaponTrail;

    [SerializeField]
    private AnimationCurve onHitScreenshake;

    [SerializeField]
    private GameObject throwTrail;

    public WeaponType WeaponType { get; private set; }  

    private Transform targetHand;
    private Transform originalTransform;
    private WeaponAnimStats animStats;

    private bool isEquipped = false;
    private bool isInAir;
    private bool canDamage = false;
    private bool isEnemy = false;
    private int damage;

    [SerializeField]
    private Collider coll;
    private Rigidbody rb;
    private bool shouldDespawn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        WeaponType = weaponType;
        originalTransform = transform;
        weaponTrail.SetActive(false);
        shouldDespawn = false;
        if (throwTrail != null)
            throwTrail.SetActive(false);
    }

    public bool Equip(Transform tar_hand, WeaponAnimStats stats, string tagName)
    {
        if (isEquipped == false)
        {
            this.transform.SetParent(tar_hand);
            gameObject.isStatic = false;
            immuneTag = tagName;
            isEquipped = true;
            animStats = stats;
            targetHand = tar_hand;
            rb.isKinematic = true;
            rb.useGravity = false;
            coll.isTrigger = true;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            ShowPickUpText(false);

            if (immuneTag == "Enemy")
                isEnemy = true;
            else 
                isEnemy = true;
            shouldDespawn = false;
            return true;
        }
        return false;

    }

    public void UnEquip()
    {
        isEquipped = false;
        weaponTrail.SetActive(false);
        animStats = null;
        canDamage = false;
        targetHand = null;
        rb.isKinematic = false;
        rb.useGravity = true;
        coll.isTrigger = false;
        transform.SetParent(GameObject.FindGameObjectsWithTag("WeaponParent")[0].transform);
        transform.localScale = Vector3.one;
        shouldDespawn = true;
        StartCoroutine(Despawn());
    }

    public void Throw(Transform playerHandTransform, float damageMultiplier, float forceMultiplier)
    {
        UnEquip();
        coll.isTrigger = true;
        StartCoroutine(ThrowDelay());
        isInAir = true;
        rb.useGravity = false;

        if (throwTrail != null)
            throwTrail.SetActive(true);
        throwDamage = Mathf.RoundToInt(throwDamage * damageMultiplier);
        rb.AddForce(Player.LookDirection * throwForce * forceMultiplier * 2, ForceMode.Impulse);
        
        rb.AddTorque(transform.right * -rotationSpeed * throwForce, ForceMode.Impulse);
    }

    private IEnumerator ThrowDelay()
    {
        yield return new WaitForSeconds(0.05f);
        coll.isTrigger = true;
    }

    private void Update()
    {
        if (isEquipped && animStats != null)
            SetStatsToAnimStats();
    }

    private void SetStatsToAnimStats()
    {
        transform.position = targetHand.position;
        transform.rotation = targetHand.rotation;
        canDamage = animStats.CanDamage;
        damage = animStats.Damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        { return; }
        if (other.gameObject.CompareTag("Ragdoll"))
        { return; }

        if (canDamage && other.GetComponent<Health>())
        {
            if (!other.CompareTag(immuneTag))
            {
                if (other.CompareTag("Player"))
                    other.GetComponent<Health>().TakeDamage(damage);
                else
                    if (other.GetComponent<Health>().TakeDamage(damage, Player.Direction, knockBack))
                {
                    Destroy(Instantiate(hitSpark, hitSparkTrans.position, hitSparkTrans.rotation, hitSparkTrans), 2);
                    GameEvents.Instance.Screenshake.Invoke(onHitScreenshake);
                }       
            }
        }

        if (isInAir && other.gameObject.GetComponent<Health>() && !other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(throwDamage, transform.forward, knockBack);
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.isTrigger)
    //    { return; }
    //    if (isInAir && collision.gameObject.GetComponent<Health>() && !collision.transform.CompareTag("Player"))
    //        collision.gameObject.GetComponent<Health>().TakeDamage(throwDamage, transform.forward, knockBack);
    
    //   if (isInAir && !collision.transform.CompareTag("Player") && !collision.transform.CompareTag("Enemy"))
    //       isInAir = false;

    //    else if (collision.gameObject.CompareTag("Ground"))
    //        isInAir = false;
            
    //    rb.useGravity = true;
    //}

    private void AttatckStarted()
    {
        if (isEnemy)
        {
            weaponTrail.SetActive(true);
        }
    }

    private void AttackEnded()
    {
        weaponTrail.SetActive(false);
    }

    public void Destroy(float waitTime)
    {
        Destroy(this.gameObject, waitTime);
    }
    
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(DespawnTimeAfterBeingDropped);
        if (shouldDespawn)
        {
            Destroy(this.gameObject);
        }
    }

    public void HitSomethingInThrow()
    {
        if (isInAir)
        {
            isInAir = false;
            coll.isTrigger = false;
            rb.useGravity = true;
            if (throwTrail != null)
                throwTrail.SetActive(false);
        }
    }
}


