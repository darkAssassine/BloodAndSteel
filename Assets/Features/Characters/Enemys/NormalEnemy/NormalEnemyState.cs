using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyState : State 
{
    protected Animator anim;
    protected NavMeshAgent agent;
    protected EnemyStateMachine machine;
    public NormalEnemyState(string name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent) : base(name)
    {
        anim = _anim;
        agent = _agent;
        machine = _stateMachine;
    }
}
