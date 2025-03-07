using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField]
    private float pickUpRange;

    [SerializeField] 
    private LayerMask pickUpLayer;

    private Interactible currentInteractible;
    private PlayerWeaponSlot weaponManager;

    private PlayerInputs input;

    private void Start()
    {
        input = GetComponent<PlayerInputs>();
        weaponManager = GetComponent<PlayerWeaponSlot>();
    }


    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange, pickUpLayer))
        {
            if (hit.transform.GetComponent<Interactible>())
            {
               

                if (hit.transform.GetComponent<Weapon>() && input.Interact)
                { 
                    weaponManager.EquipWeapon(hit.transform.GetComponent<Weapon>());
                }
                else if (hit.transform.GetComponent<Weapon>())
                {
                    hit.transform.GetComponent<Weapon>().ShowPickUpText(true);
                }
                else if (currentInteractible != null)
                {
                    currentInteractible.ShowPickUpText(true);
                }
                currentInteractible = hit.transform.GetComponent<Interactible>();
            }
           
        }
        else if (currentInteractible != null)
        {
            currentInteractible.ShowPickUpText(false);
        }
    }
}
