using UnityEngine;
using StateMachine;
using UnityEngine.AI;

public class baseAI : gameEntity {

    public gameEntity target;
    public float viewDistance = 0.1f;
    public stateMachine<baseAI> stateMachine { get; set; }
    public NavMeshAgent navMesh;

    public float projectileRange = 200f;
    public float weaponDamage;


    public ParticleSystem musFlash;
    public GameObject paintSplat;

    public AudioSource shotEffect;

    public RaycastHit chaseTarget;
    public RaycastHit hitTarget;

    float scaleLimit = 0.1f;


    public bool fire = false;
    public bool chase = false;
    public bool flee = false;

    public GameObject healPoint;


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
            if(target)
            {
                chase = true;
            }
        }

            

        if (Physics.Raycast(transform.position, transform.forward, out hitTarget))
        {
            fire = hitTarget.transform.GetComponent<playerMove>();
        }
        if (Health <= 5)
        {
            flee = true;
            fire = false;
            chase = false;
        }
        else
        {
            flee = false;
        }





      

        Debug.DrawLine(transform.position, transform.forward * viewDistance);
        stateMachine.Update();
    }


    public void Fire()
    {

        Vector3 direction = Random.insideUnitCircle * scaleLimit;

        shotEffect.Play();
         musFlash.Play(); //Starts muzzle flash effect

            if(Physics.Raycast(transform.position, transform.forward + direction, out hitTarget))
            {
            GameObject paint;
            if (!hitTarget.transform.GetComponent<playerMove>())
            {


                paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));



                Destroy(paint, 20.0f);
            }
            else
            {
                hitTarget.transform.GetComponent<gameEntity>().takeDamage(1.0f);
            }
        }
        
        


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

}
