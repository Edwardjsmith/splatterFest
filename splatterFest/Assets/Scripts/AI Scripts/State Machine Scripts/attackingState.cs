using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class attackingState : State<baseAI>
{
    float fireRate = 0;
    private static attackingState _instance;

    private attackingState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static attackingState Instance
    {
        get
        {
            if (_instance == null)
            {
                new attackingState();
            }

            return _instance;
        }
    }

    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering chase");
        
    }

    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting chase");
    }

    public override void UpdateState(baseAI owner)
    {
        if (!owner.fire)
        {
            owner.stateMachine.changeState(chaseState.Instance);
        }
        if (fireRate <= 0)
        {
            owner.Fire();
            fireRate = 2.0f;
        }
        fireRate -= Time.deltaTime;
    }
}
