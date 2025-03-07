using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyChaseState : BigEnemyState
{
    private float time;
    private float findPathInterval;

    public BigEnemyChaseState(string name, BigEnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _findPathInterval) : base(name, _stateMachine, _anim, _agent) 
    {
        findPathInterval = _findPathInterval;
    }

    public override void Enter()
    {
        base.Enter();
        agent.SetDestination(Player.Position);
        anim.Play("walking");
    }

    public override void Exit() 
    {
        base.Exit();
    }
    public override void Update() 
    {
        base.Update();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        time += Time.fixedDeltaTime;
        if (time > findPathInterval)
        {
            time = 0;
            agent.SetDestination(Player.Position);
        }
        if (machine.IsInAttackRange)
        {
            machine.ChangeState(machine.AttackState);
        }
    }
}
