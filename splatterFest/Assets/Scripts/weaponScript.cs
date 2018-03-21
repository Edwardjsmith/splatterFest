using UnityEngine;

public class weaponScript : MonoBehaviour {

    public Camera view;
   
    public float projectileRange = 100f;
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
                target.takeDamage(2.0f);
                GameObject paint = Instantiate(paintSplat, hitTarget.point, hitTarget.transform.rotation * Quaternion.Euler(1, 1, -90));

                Destroy(paint, 20.0f);

                if(target.targetHealth <= 0)
                {
                    Destroy(paint);
                }
            }
        }



    }
}
