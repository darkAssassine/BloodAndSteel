using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    public State returnState;
    protected virtual void Start()
    {
        currentState = GetInitialState();
        if (currentState != null )  
            currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.Update();

        if (currentState == null)
            Debug.LogWarning($"{this.gameObject.name} has no CurrentState!!!");
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(State newState)
    {
        returnState = currentState;
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual State GetInitialState()
    {
        return null;
    }
}
