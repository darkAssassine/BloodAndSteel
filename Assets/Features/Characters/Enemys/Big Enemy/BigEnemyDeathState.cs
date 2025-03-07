using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyDeathState : BigEnemyState
{
    public BigEnemyDeathState(string name, BigEnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent) : base(name, _stateMachine, _anim, _agent)
    {

    }

    public override void Enter()
    {
        base.Enter();
        agent.ResetPath();
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
    }
}
