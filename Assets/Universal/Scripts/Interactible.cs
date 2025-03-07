using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    //private GameObject PickUpText;

    public virtual void ShowPickUpText(bool shouldShow)
    {
            //PickUpText.SetActive(shouldShow);
    }

    public virtual void Interact()
    {

    }
}
    