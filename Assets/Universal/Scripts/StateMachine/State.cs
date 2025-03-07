using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public string Name;

    public virtual void Enter() { //Debug.Log($"{stateMachine.name} has entered {Name}"); 
    }          
    public virtual void Update() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }


    public State(string name) 
    {
        Name = name;
    }
}
