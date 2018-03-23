using UnityEngine;
using StateMachine;

public class baseAI : gameEntity {

    public playerMove target;
    public float viewDistance;
    public stateMachine<baseAI> stateMachine { get; set; }

	// Use this for initialization
	void Start ()
    {
        stateMachine = new stateMachine<baseAI>(this);
        stateMachine.changeState(idleState.Instance);
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hitTarget;
        if(Physics.Raycast(transform.position, transform.forward, out hitTarget, viewDistance))
        { 
            target = hitTarget.transform.GetComponent<playerMove>();
        }
        else
        {
            target = null;
        }

        Debug.DrawRay(transform.position, transform.forward * viewDistance, Color.red);

        stateMachine.Update();
    }
}
