using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
public class NormalEnemy : Enemy
{
    [SerializeField]
    private float distanceToAttack;

    [SerializeField]
    private float minIdleStance;

    [SerializeField] 
    private float maxIdleStance;

    private Vector3 playerPos;
    private NavMeshAgent agent;
    private GameObject player;
    private Rigidbody rb;
    private float originalSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerPos = player.transform.position;
        agent.SetDestination(playerPos);
        originalSpeed = agent.speed;
    }

    protected override void Update()
    {
       base.Update();
       EvaluateState();
    }

    private void EvaluateState()
    {
        if (agent.remainingDistance < distanceToAttack)
        {
            Attack();
        }
        else
        {
            Chase();
        }
           
        playerPos = player.transform.position;
        playerPos.y = 0;
        agent.SetDestination(playerPos);
        anim.SetFloat("Speed", agent.speed / agent.velocity.magnitude);
    }

    private void Chase()
    {
        agent.speed = originalSpeed;
        anim.SetBool("ShouldAttack", false);
    }

    private void Attack()
    {
        agent.speed = 0;

        transform.LookAt(playerPos);
        if (currentWeapon != null)
        {
            switch (currentWeapon.WeaponType)
            {
                case WeaponType.OneHanded:
                    //anim.SetBool("OneHandAttack", true);
                    break;

                case WeaponType.TwoHanded:
                    //anim.SetBool("TwoHandAttack", true);
                    break;
                case WeaponType.Speers:
                    //anim.SetBool("SpeerAttack", true);
                    break;
            }
        }
        StartCoroutine(AttackIdle());
    }

    private IEnumerator AttackIdle()
    {
        anim.SetBool("ShouldAttack", false);
        yield return new WaitForSeconds(Random.Range(0.4f,1));
        anim.SetBool("ShouldAttack", true);
        yield return new WaitForSeconds(1);
    }
}
