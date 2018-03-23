using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class attackingState : State<baseAI>
{

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
        owner.Fire();
    }

    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting chase");
    }

    public override void UpdateState(baseAI owner)
    {
        if (!owner.target)
        {
            owner.stateMachine.changeState(chaseState.Instance);
        }
    }
}
