using UnityEngine;
using StateMachine;
using UnityEngine.AI;

public class baseAI : gameEntity {

    public gameEntity target;
    float viewDistance = 30f;
    stateMachine<baseAI> stateMachine { get; set; }
    public NavMeshAgent navMesh;

    RaycastHit chaseTarget;

    public GameObject[] healPoint;

    float fireRate = 0;


    // Use this for initialization
    void Start()
    {
        stateMachine = new stateMachine<baseAI>(this);
        stateMachine.changeState(idleState.Instance);
        healPoint = GameObject.FindGameObjectsWithTag("healPoint");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawLine(transform.position, transform.forward * viewDistance);
        target = FindClosestEnemy();
        stateMachine.Update();
    }

    public void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (Health <= 5)
        {
            stateMachine.changeState(fleeState.Instance);
        }

        if (distance > viewDistance / 2)
        {
            stateMachine.changeState(chaseState.Instance);
        }
        else if (fireRate <= 0)
        {
            Fire();
            fireRate = 2.0f;
        }

        fireRate -= Time.deltaTime;
    }

    public void Chase()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance > viewDistance)
        {
            stateMachine.changeState(idleState.Instance);
        }
        if (distance <= viewDistance)
        {
            navMesh.SetDestination(target.transform.position);
        }
        if (distance < viewDistance / 2)
        {
            stateMachine.changeState(attackingState.Instance);
        }
        
        
    }

    public void Flee()
    {
        navMesh.SetDestination(closestHealPoint().transform.position);

        if (Health == 10)
        {
            stateMachine.changeState(chaseState.Instance);
        }
    }

    public void Idle()
    {
        if (target != null)
        {
            stateMachine.changeState(chaseState.Instance);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    gameEntity FindClosestEnemy()
    {
        gameEntity[] gos = FindObjectsOfType<gameEntity>();
        gameEntity closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(gameEntity go in gos)
        {
            if (go != this)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }

        return closest;
    }

    GameObject closestHealPoint()
    {
        
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in healPoint)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }

}
