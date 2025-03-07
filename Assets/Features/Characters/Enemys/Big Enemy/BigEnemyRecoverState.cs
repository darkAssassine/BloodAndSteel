using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyRecoverState : BigEnemyState
{
    private float recoverTime;
    private float recoverFinishAnimTime;
    private float time;
    public BigEnemyRecoverState(string name, BigEnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _recoverTime, float recoverFinishAnimTime) : base(name, _stateMachine, _anim, _agent)
    {
        recoverTime = _recoverTime;
        this.recoverFinishAnimTime = recoverFinishAnimTime;
    }

    public override void Enter()
    {
        base.Enter();
        agent.ResetPath();
        anim.Play("recover_idle");
        time = 0;   
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        time += Time.deltaTime;
        if (time > recoverTime) 
        {
            anim.Play("back_to_walking");
        }

        if (time >= recoverTime + recoverFinishAnimTime)
        {
            machine.ChangeState(machine.ChaseState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
