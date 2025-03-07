using UnityEngine;

public class SpawnStartWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    [SerializeField]
    string immuneTag;

    [SerializeField]
    private WeaponAnimStats stats;

    [SerializeField]
    private HealthEvent healthEvent;

    [SerializeField]
    private Transform weaponHand;

    public GameObject currentWeapon { get; private set; }

    private void Start()
    {
        currentWeapon = Instantiate(weapons[Random.Range(0, weapons.Length)], weaponHand);
        currentWeapon.GetComponent<Weapon>().Equip(weaponHand, stats, immuneTag);
    }
}
