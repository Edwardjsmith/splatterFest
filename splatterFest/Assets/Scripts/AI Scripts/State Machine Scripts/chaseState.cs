using UnityEngine;
using StateMachine;

public class chaseState : State<baseAI>
{

        private static chaseState _instance;

        private chaseState()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = this;
        }

        public static chaseState Instance
        {
            get
            {
                if (_instance == null)
                {
                    new chaseState();
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
            if(owner.target == null)
            {
                owner.stateMachine.changeState(idleState.Instance);
            }

        if (owner.target != null && owner.fire == false)
        {
            float distance = Vector3.Distance(owner.target.transform.position, owner.transform.position);

            if (distance <= owner.viewDistance)
            {
                owner.navMesh.SetDestination(owner.target.transform.position);
            }
        }
        else if(owner.fire == true)
        {
            owner.stateMachine.changeState(attackingState.Instance);
        }
    }
    }

