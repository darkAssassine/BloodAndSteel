using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField]
    private HealthEvent healthEvent;

    [SerializeField, Range(0, 1.0f)]
    private float weaponDropChange;

    [SerializeField, Range(0,1.0f)]
    private float healthDropsChange;

    [SerializeField]
    private SpawnStartWeapon spawnStartWeapon;

    [SerializeField]
    private GameObject healthDrop;

    private void Start()
    {
        healthEvent.OnDeath += Drop;
    }

    private void OnDisable()
    {
        healthEvent.OnDeath -= Drop;
    }

    private void Drop()
    {
        if (Random.Range(0.0f, 1.0f) < weaponDropChange)
        {
           spawnStartWeapon.currentWeapon.GetComponent<Weapon>().UnEquip();
        }

        if (Random.Range(0.0f, 1.0f) < healthDropsChange)
        {
            Instantiate(healthDrop, transform.position + Vector3.up, transform.rotation);
        }
    }
}
