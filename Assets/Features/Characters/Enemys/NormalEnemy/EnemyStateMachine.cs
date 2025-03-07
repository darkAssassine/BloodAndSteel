using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [SerializeField]
    private float distanceToIdle, minWaitTillAttack, maxWaitTillAttack, flinchAnimationTime, kickedAwayAnimTime, timeToChangeStateAfterAttack, pathFindInterval;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private HealthEvent healthEvent;


    [SerializeField]
    private GameObject ragdolls;

    [SerializeField]
    private float ragdollsTimeToDespawn;
    [SerializeField]
    private ParticleSystem dustTrail;
    [SerializeField]
    private PlayRandomSound walkSounds;

    public IdleState IdleState;
    public ChaseState ChaseState;
    public AttackState AttackState;
    public FlinchState FlinchState;
    public DeathState DeathState;
    public KickState KickState;

    [HideInInspector]
    public bool IsInAttackRange { get; private set; }

    private void OnEnable()
    {
        healthEvent.OnHit += Flinch;
        healthEvent.OnDeath += Death;
        healthEvent.OnKick += Kick;
    }

    private void OnDisable()
    {
        healthEvent.OnHit -= Flinch;
        healthEvent.OnDeath -= Death;
        healthEvent.OnKick -= Kick;
    }
    private void Awake()
    {
        IdleState = new IdleState("Idle", this, anim, agent, distanceToIdle);
        ChaseState = new ChaseState("Chase", this, anim, agent, distanceToIdle, pathFindInterval, dustTrail, walkSounds);
        AttackState = new AttackState("Chase", this, anim, agent, minWaitTillAttack, minWaitTillAttack, timeToChangeStateAfterAttack);
        DeathState = new DeathState("Death", this, anim, agent);
        FlinchState = new FlinchState("Flinch", this, anim, agent, flinchAnimationTime);
        KickState = new KickState("Kick", this, anim, agent, kickedAwayAnimTime);
    }

    protected override void Start()
    {
        base.Start();
        EnemyManager.Instance.CurrentEnemyCount += 1;
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

    private void Flinch()
    {
        ChangeState(FlinchState);
    }
    private void Kick()
    {
        ChangeState(KickState);
    }

    private void Death()
    {
        ChangeState(DeathState);
        Destroy(Instantiate(ragdolls, transform.position, transform.rotation), ragdollsTimeToDespawn);
        EnemyManager.Instance.CurrentEnemyCount -= 1;
        PlayerPrefs.SetInt("EnemysDefeated", PlayerPrefs.GetInt("EnemysDefeated") + 1);
        Destroy(this.gameObject);
    }

}

