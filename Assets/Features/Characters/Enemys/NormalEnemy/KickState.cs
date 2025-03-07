using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KickState : NormalEnemyState
{
    private float flinchAnimTime;
    private float time;
    public KickState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _flinchAnimTime) : base(_name, _stateMachine, _anim, _agent)
    {
        flinchAnimTime = _flinchAnimTime;
    }

    public override void Enter()
    {
        base.Enter();

        float angle = -Vector3.SignedAngle(Vector3.forward, (machine.transform.position - Player.Position), Vector3.up);

        angle += machine.transform.eulerAngles.y + 45;

        if (angle >= -90 && angle <= 90)
        {
            anim.Play("kicked_away_back");
            machine.transform.LookAt(Player.Position);
            machine.transform.Rotate(0, 180, 0);
        }
        else
        {
            // Hit from the back
            machine.transform.LookAt(Player.Position);
            anim.Play("kicked_away_front");
        }

        agent.ResetPath();
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
        if (time >= flinchAnimTime)
        {
            if (machine.returnState is FlinchState == true)
            {
                machine.ChangeState(machine.ChaseState);
                // Debug.Log("HasExited");
            }

            else if (machine.returnState != null)
            {
                machine.ChangeState(machine.returnState);
                //Debug.Log("HasExited");
            }

            time = 0;
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
