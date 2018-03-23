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
            owner.navMesh.SetDestination(owner.target.transform.position);
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
        }
    }

