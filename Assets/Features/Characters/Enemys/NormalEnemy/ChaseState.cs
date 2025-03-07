using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : NormalEnemyState
{
    private float distanceToIdle;
    private float SetPathInterval;
    private float time;
    private ParticleSystem dustTrail;
    private PlayRandomSound walkSound;
    public ChaseState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _distanceToIdle, float pathFindInterval, ParticleSystem dust, PlayRandomSound walkSound) : base(_name, _stateMachine, _anim, _agent)
    {
        dustTrail = dust;
        SetPathInterval = pathFindInterval;
        this.walkSound = walkSound;
    }

    public override void Enter()
    {
        base.Enter();
        anim.Play("running");
        dustTrail.Play();
        agent.SetDestination(Player.Position);
        walkSound.Play();

    }

    public override void Exit()
    {
        base.Exit();
        dustTrail.Stop();
        walkSound.Stop();
    }

    public override void Update()
    {
        base.Update();

        if (Mathf.Abs(Vector3.Distance(Player.Position, machine.transform.position)) < distanceToIdle && EnemyManager.Instance.MaxEnemysInAttackRange <= EnemyManager.Instance.EnemysInAttackRange)
        {
            machine.ChangeState(machine.IdleState);
        }
        if (machine.IsInAttackRange && EnemyManager.Instance.MaxEnemysInAttackRange > EnemyManager.Instance.EnemysInAttackRange)
        {
           machine.ChangeState(machine.AttackState);
        }
        if (agent.velocity == Vector3.zero)
        {
            anim.Play("idle_combat");
        }
        else
            anim.Play("running");

    }

    public override void UpdatePhysics()
    {
        time += Time.fixedDeltaTime;
        if (time > SetPathInterval)
        {
            time = 0;
            agent.SetDestination(Player.Position);
        }
        base.UpdatePhysics();
    }
}
