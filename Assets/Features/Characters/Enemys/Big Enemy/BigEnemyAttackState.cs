using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyAttackState : BigEnemyState
{
    private float attackAnimTime;
    private float time;
    public BigEnemyAttackState(string name, BigEnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float animTime) : base(name, _stateMachine, _anim, _agent)
    {
        attackAnimTime = animTime;
    }

    public override void Enter()
    {
        base.Enter();
        anim.Play("heavy_attack");
        agent.ResetPath();
        time = 0;
    }

    public override void Update()
    {
        time += Time.deltaTime;
        if (time >= attackAnimTime)
        {
            machine.ChangeState(machine.RecoverState);
        }
        base.Update();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
