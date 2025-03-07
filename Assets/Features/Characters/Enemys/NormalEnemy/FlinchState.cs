using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlinchState : NormalEnemyState
{
    private float flinchAnimTime;
    private float time;
    public FlinchState(string _name, EnemyStateMachine _stateMachine, Animator _anim, NavMeshAgent _agent, float _flinchAnimTime) : base(_name, _stateMachine, _anim, _agent)
    {
        flinchAnimTime = _flinchAnimTime;
    }

    public override void Enter()
    {
        base.Enter();
   
        float angle = -Vector3.SignedAngle(Vector3.forward, (machine.transform.position - Player.Position), Vector3.up);
        
        angle += machine.transform.eulerAngles.y + 45;

        if (angle >= -45 && angle <= 45)
        {
            // Hit from the front
            anim.Play("one_handed_flinch_front");
        }
        else if (angle > 45 && angle <= 135)
        {
            // Hit from the left
            anim.Play("one_handed_flinch_left");
        }
        else if (angle < -45 && angle >= -135)
        {
            // Hit from the right
            anim.Play("one_handed_flinch_right");
            
        }
        else
        {
            // Hit from the back
            
            anim.Play("flinch");
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
        base .Update();
        time += Time.deltaTime;
        if (time >= flinchAnimTime)
        {
            if (machine.returnState is FlinchState == true)
            {
                machine.ChangeState(machine.ChaseState);
               // Debug.Log("HasExited");
            }

            else if (machine.returnState != null )
            {
                machine.ChangeState(machine.ChaseState);
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
