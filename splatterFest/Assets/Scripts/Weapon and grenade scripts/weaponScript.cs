using UnityEngine;
using UnityEngine.UI;

public class weaponScript : MonoBehaviour {

    public Camera view;

    public Slider grenadeCoolDown;
   
    public float projectileRange = 200f;
    public float weaponDamage;
    public float throwPower;
    public ParticleSystem musFlash;
    public GameObject paintSplat;

    public GameObject grenadeSpawn;

    public GameObject grenade;

    public AudioSource shotEffect;

    float grenadeTimer;

    // Use this for initialization
    void Start ()
    {
        //gameObject.SetActive(false); //So the player does not start with a weapon
        grenadeTimer = 0.0f;
        grenadeCoolDown.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        grenadeCoolDown.value = grenadeTimer;
        if (Input.GetButtonDown("Fire1") && !playerMove.sprint)
        {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.G) && grenadeTimer <= 0)
        {
            throwGrenade();
            grenadeTimer = 6.0f;
            grenadeCoolDown.gameObject.SetActive(true);
        }

        if(grenadeTimer <= 0)
        {
            grenadeCoolDown.gameObject.SetActive(false);
        }
      

        
        grenadeTimer -= Time.deltaTime;
        Debug.DrawRay(view.transform.position, view.transform.forward * projectileRange, Color.red);
	}

    public void Fire()
    {
        shotEffect.Play();
        musFlash.Play(); //Starts muzzle flash effect
        

        RaycastHit hitTarget;
        if (Physics.Raycast(view.transform.position, view.transform.forward, out hitTarget, projectileRange))
        {
            baseAI target = hitTarget.transform.GetComponent<baseAI>();

            GameObject paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal)); //Spawns the paint splat
            Destroy(paint, 20.0f); //Destroys paint after 20 secs

            if (target != null) //As long as there is a target..
            {
                target.takeDamage(weaponDamage); //inflict the damage
               
  
                if(target.Health <= 0)
                {
                    Destroy(paint); //Destroys paint along with parent
                }
            }
        }



    }

    public void throwGrenade()
    {
        GameObject gren = Instantiate(grenade, grenadeSpawn.transform.position, transform.rotation);

        gren.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwPower * Time.deltaTime);
    }
}
