using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyState : State
{
    protected Animator anim;
    protected NavMeshAgent agent;
    protected BigEnemyStateMachine machine;
    public BigEnemyState(string name, BigEnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent) : base(name)
    {
        anim = _anim;
        agent = _agent;
        machine = _stateMachine;
    }
}
