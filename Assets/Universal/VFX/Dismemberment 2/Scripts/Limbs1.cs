using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbs1 : MonoBehaviour
{
    EnemyDismemberment EnemyDismemberment;

    [SerializeField] Limbs[] childLimbs;
    [SerializeField] GameObject limbPrefab;
    [SerializeField] GameObject woundHole;

    [SerializeField] GameObject bloodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EnemyDismemberment = transform.root.GetComponent<EnemyDismemberment>();

        if(woundHole !=null)
        {
            woundHole.SetActive(false);
        }
        GetHit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        if(childLimbs.Length > 0)
        {
            foreach(Limbs limb in childLimbs)
            {
                if(limb != null)
                {
                    limb.GetHit();
                }
            }
        }

        if (woundHole != null)
        {
            woundHole.SetActive(true);

            if (bloodPrefab != null)
            {
                Instantiate(bloodPrefab, woundHole.transform.position, woundHole.transform.rotation);
            }

        }
        

        if(limbPrefab !=null)
        {
            Instantiate(limbPrefab, transform.position, transform.rotation);
        }

        transform.localScale = Vector3.zero;

        EnemyDismemberment.GetKilled();

        Destroy(this);
    }
}