using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathState : NormalEnemyState
{
    public DeathState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent) : base(_name, _stateMachine, _anim, _agent)
    {
    }

    public override void Enter()
    {
        base.Enter();
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
