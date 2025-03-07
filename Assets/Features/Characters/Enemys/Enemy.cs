using UnityEngine;


[RequireComponent(typeof(HealthEvent))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected Animator anim;

    [SerializeField]
    private GameObject healthDrop;

    [SerializeField]
    private float weaponDropChange = 0.5f;

    [SerializeField]
    private float healthDropChange = 0.5f;

    [SerializeField]
    private float timeToDespawn = 1f;

    protected Weapon currentWeapon;
    HealthEvent healthEvent;

    public void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }

    protected virtual void Start()
    {
        healthEvent = GetComponent<HealthEvent>();
        healthEvent.OnDeath += OnDeath;
        
    }

    private void OnDeath()
    {
        if (Random.Range(0f, 1f) <= weaponDropChange)
            currentWeapon.UnEquip();
        else
            currentWeapon.Destroy(timeToDespawn);

        if (Random.Range(0f, 1f) <= healthDropChange)
            Instantiate(healthDrop, transform.position + Vector3.up, transform.rotation);
        Destroy(transform.parent.gameObject, timeToDespawn);
    }

    protected virtual void Update()
    {
        if (Vector3.Distance(Player.Position, transform.position) > 100)
        {
            healthEvent = GetComponent<HealthEvent>();
            healthEvent.OnDeath.Invoke();
            Debug.Log("enemy out of map");
        }
    }

}
