using UnityEngine;
using StateMachine;
using UnityEngine.AI;

public class baseAI : gameEntity {

    public playerMove target;
    public float viewDistance;
    public stateMachine<baseAI> stateMachine { get; set; }
    public NavMeshAgent navMesh;

    public float projectileRange = 200f;
    public float weaponDamage;


    public ParticleSystem musFlash;
    public GameObject paintSplat;

    public AudioSource shotEffect;

    // Use this for initialization
    void Start ()
    {
        stateMachine = new stateMachine<baseAI>(this);
        stateMachine.changeState(idleState.Instance);
	}
	
	// Update is called once per frame
	void Update ()
    {

        
        Debug.DrawRay(transform.position, transform.forward * viewDistance, Color.red);

        stateMachine.Update();
    }


    public void Fire()
    {
        shotEffect.Play();
        musFlash.Play(); //Starts muzzle flash effect



        if (Physics.Raycast(transform.position, transform.forward, out hitTarget, projectileRange))
        {
            gameEntity target = hitTarget.transform.GetComponent<gameEntity>();

            GameObject paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal)); //Spawns the paint splat
            Destroy(paint, 20.0f); //Destroys paint after 20 secs

            if (target != null) //As long as there is a target..
            {
                target.takeDamage(weaponDamage); //inflict the damage


                if (target.Health <= 0)
                {
                    Destroy(paint); //Destroys paint along with parent
                }
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        target = other.transform.GetComponent<playerMove>();
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
    }
}
