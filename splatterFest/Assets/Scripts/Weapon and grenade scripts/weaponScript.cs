using UnityEngine;
using UnityEngine.UI;

public class weaponScript : gameEntity {

    public Camera view;
    public Slider grenadeCoolDown;


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

    
}
