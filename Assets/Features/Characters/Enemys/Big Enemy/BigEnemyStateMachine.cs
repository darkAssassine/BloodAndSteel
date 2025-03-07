using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyStateMachine : StateMachine
{
    public Health Health;

    [SerializeField]
    private HealthEvent healthEvent;

    [SerializeField]
    private float attackAnimationTime, recoverTime, recoverFinishedAnimTime, findPathInterval;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject ragdolls;

    [SerializeField]
    private float ragdollsTimeToDespawn;

    [HideInInspector]
    public bool IsInAttackRange { get; private set; }



    public BigEnemyChaseState ChaseState;
    public BigEnemyAttackState AttackState;
    public BigEnemyRecoverState RecoverState;
    public BigEnemyDeathState DeathState;


    private void Awake()
    {
        ChaseState = new BigEnemyChaseState("Chase", this, anim, agent,findPathInterval);
        AttackState = new BigEnemyAttackState("Chase", this, anim, agent, attackAnimationTime);
        RecoverState = new BigEnemyRecoverState("Death", this, anim, agent, recoverTime, recoverFinishedAnimTime);
        DeathState = new BigEnemyDeathState("Flinch", this, anim, agent);

        IsInAttackRange = false;
        Health.CanTakeDamage = true;
    }

    protected override void Start()
    {
        base.Start();
        EnemyManager.Instance.CurrentEnemyCount += 1;
        Health.CanTakeDamage = true;
    }


    private void OnEnable()
    {
        healthEvent.OnDeath += Death;
        healthEvent.OnHit += Hit;
    }

    private void OnDisable()
    {
        healthEvent.OnDeath -= Death;
        healthEvent.OnHit -= Hit;
    }
    protected override State GetInitialState()
    {
        return ChaseState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInAttackRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInAttackRange = false;
        }
    }

    private void Death()
    {
        ChangeState(DeathState);
        Destroy(Instantiate(ragdolls, transform.position, transform.rotation ), ragdollsTimeToDespawn);
        EnemyManager.Instance.CurrentEnemyCount -= 1;
        PlayerPrefs.SetInt("EnemysDefeated", PlayerPrefs.GetInt("EnemysDefeated") + 1);
        Destroy(this.gameObject);
    }

    private void Hit()
    {
        if (currentState == RecoverState)
        {
            //anim.Play("flinch_360");
        }
    }
}
