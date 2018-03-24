using UnityEngine;
using StateMachine;
using UnityEngine.AI;

public class baseAI : gameEntity {

    public gameEntity target;
    public float viewDistance = 2.0f;
    public stateMachine<baseAI> stateMachine { get; set; }
    public NavMeshAgent navMesh;

    public float projectileRange = 200f;
    public float weaponDamage;


    public ParticleSystem musFlash;
    public GameObject paintSplat;

    public AudioSource shotEffect;

    public RaycastHit chaseTarget;
    public RaycastHit hitTarget;


    public bool fire = false;
    public bool chase = false;

    // Use this for initialization
    void Start ()
    {
        stateMachine = new stateMachine<baseAI>(this);
        stateMachine.changeState(idleState.Instance);
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Physics.SphereCast(transform.position, viewDistance, transform.forward, out chaseTarget))
        {
            gameEntity target = chaseTarget.transform.GetComponent<playerMove>();
        }


        if (Physics.Raycast(transform.position, transform.forward, out hitTarget))
        {
            fire = true;
        }
        else
        {
            fire = false;
        }

            Debug.DrawLine(transform.position, transform.forward * viewDistance);
        stateMachine.Update();
    }


    public void Fire()
    {

        
        
                shotEffect.Play();
                musFlash.Play(); //Starts muzzle flash effect

                GameObject paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
           
        
        


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

}
