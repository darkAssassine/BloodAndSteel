using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDismemberment : MonoBehaviour
{
    List<Rigidbody> ragdollRigids;
    List<Limbs> limbs;

    [SerializeField, Range(0, 1)]
    private float oneLimb, twoLimbs, threeLimbs, fourLimbs;

    private void Awake()
    {
        ragdollRigids = new List<Rigidbody>(transform.GetComponentsInChildren<Rigidbody>());
        limbs = new List<Limbs>(transform.GetComponentsInChildren<Limbs>());
        GetKilled();
    }

    void ActivateRagdoll()
    {
        float randomChange = Random.Range(0f, 1f);
        if (randomChange < fourLimbs)
        {
            Dismember(4);
        }
        else if(randomChange < threeLimbs) 
        {
            Dismember(3);
        }
        else if(randomChange < twoLimbs)
        {
            Debug.Log(2);
            Dismember(2);
        }
        else if(randomChange < oneLimb)
        {
            Dismember(1);
        }
        else
        {
        }
        for(int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = true;
            ragdollRigids[i].isKinematic = false;
        }
    }

    void Dismember(int i)
    {
        for (int a = 0; a < i; a++)
        { 
            if (limbs.Count > 0)
            {
                limbs[Random.Range(0, limbs.Count)].GetHit();
                ragdollRigids = new List<Rigidbody>(transform.GetComponentsInChildren<Rigidbody>());
            }
        }
    }

    public void GetKilled()
    {
        ActivateRagdoll();
    }

    void DeactivateRagdoll()
    {
        for (int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = false;
            ragdollRigids[i].isKinematic = true;
        }
    }
}