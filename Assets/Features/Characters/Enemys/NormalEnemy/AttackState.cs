using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AttackState : NormalEnemyState
{
    private float minAttackDelay;
    private float maxAttackDelay;
    private float time;
    private bool shouldChangeState = false;
    private float neededTime;
    private float timeToChangeState;
    private float timeSinceLastAttack;

    public AttackState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _minAttackDelay, float _maxAttackDelay, float _timeToChangeState) : base(_name, _stateMachine, _anim, _agent)
    { 
        minAttackDelay = _minAttackDelay;
        maxAttackDelay = _maxAttackDelay;
        timeToChangeState = _timeToChangeState;
    }

    public override void Enter()
    {
        base.Enter();
        anim.Play("light_attack_01");
        neededTime = Random.Range(minAttackDelay, maxAttackDelay);
        agent.ResetPath();
        shouldChangeState = false;
        EnemyManager.Instance.EnemysInAttackRange += 1;
        time = 0;
    }

    public override void Exit()
    {
        base.Exit();
        EnemyManager.Instance.EnemysInAttackRange -= 1;
    }

    public override void Update()
    {
        base.Update();
        AttackTimer();

        if (machine.IsInAttackRange == false || EnemyManager.Instance.MaxEnemysInAttackRange <= EnemyManager.Instance.EnemysInAttackRange)
        {
            shouldChangeState = true;
        }
        else
        {
            shouldChangeState = false ;
        }

        if (shouldChangeState && time > timeToChangeState)
        {
            machine.ChangeState(machine.ChaseState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void AttackTimer()
    {
        time += Time.deltaTime;
        if (time > neededTime && shouldChangeState == false)
        {
            anim.Play("light_attack_01");
            time = 0;
            neededTime = Random.Range(minAttackDelay, maxAttackDelay);
        }
    }
}
