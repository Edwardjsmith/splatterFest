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
            owner.Chase();
        }
        
    }


