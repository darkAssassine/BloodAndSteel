using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbs : MonoBehaviour
{
    [SerializeField] GameObject limbPrefab;
    [SerializeField] GameObject woundHole;

    [SerializeField] GameObject bloodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(woundHole !=null)
        {
            woundHole.SetActive(false);
        }
        //GetHit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {   if (woundHole != null)
        {
            woundHole.SetActive(true);
        }

        if (bloodPrefab != null)
        {
            Instantiate(bloodPrefab, transform.position, transform.rotation, transform.parent);
        }




        if (limbPrefab !=null)
        {
            GameObject limp = Instantiate(limbPrefab, transform.position, transform.rotation, transform.parent);
            limp.transform.localScale *= 0.01f;
        }

        transform.localScale = Vector3.zero;

        Destroy(this);
    }
}