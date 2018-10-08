using UnityEngine;
using StateMachine;

public class fleeState : State<baseAI>
{

    private static fleeState _instance;

    private fleeState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static fleeState Instance
    {
        get
        {
            if (_instance == null)
            {
                new fleeState();
            }

            return _instance;
        }
    }

    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering flee");
    }

    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting flee");
    }

    public override void UpdateState(baseAI owner)
    {
        owner.Flee();
    }
        
}