
using UnityEngine;
using StateMachine;
public class idleState : State<baseAI>
{
    private static idleState _instance;

    private idleState()
    {
        if(_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static idleState Instance
    {
        get
        {
            if(_instance == null)
            {
                new idleState();
            }

            return _instance;
        }
    }

    public override void EnterState(baseAI owner)
    {
        Debug.Log("Entering idle");
    }

    public override void ExitState(baseAI owner)
    {
        Debug.Log("Exiting idle");
    }

    public override void UpdateState(baseAI owner)
    {
        owner.Idle();
    }
}
