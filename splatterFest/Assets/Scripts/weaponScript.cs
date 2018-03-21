using UnityEngine;

public class weaponScript : MonoBehaviour {

    public Camera view;
   
    public float projectileRange = 100f;
    public float weaponDamage;
    public ParticleSystem musFlash;
    public GameObject paintSplat;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
	}

    public void Fire()
    {
        musFlash.Play();
        RaycastHit hitTarget;
        if (Physics.Raycast(view.transform.position, view.transform.forward, out hitTarget, projectileRange))
        {
            shootTarget target = hitTarget.transform.GetComponent<shootTarget>();

            if (target != null)
            {
                target.takeDamage(weaponDamage);
                GameObject paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));

                Destroy(paint, 20.0f);

                if(target.targetHealth <= 0)
                {
                    Destroy(paint);
                }
            }
        }



    }
}
