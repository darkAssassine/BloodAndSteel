using UnityEngine;
using UnityEngine.AI;
using System;
public class IdleState : NormalEnemyState
{
    private float distanceToIdle;

    public IdleState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _distanceToIdle) : base(_name, _stateMachine, _anim, _agent)
    {
        distanceToIdle = _distanceToIdle;
    }

    public override void Enter()
    {
        base.Enter();
        anim.Play("idle_combat");
        agent.ResetPath();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Mathf.Abs(Vector3.Distance(Player.Position, machine.transform.position)) > distanceToIdle || EnemyManager.Instance.EnemysInAttackRange < EnemyManager.Instance.MaxEnemysInAttackRange) 
        {
            machine.ChangeState(machine.ChaseState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
