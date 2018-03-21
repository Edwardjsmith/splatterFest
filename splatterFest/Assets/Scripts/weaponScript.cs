﻿using UnityEngine;

public class weaponScript : MonoBehaviour {

    public Camera view;
   
    public float projectileRange = 200f;
    public float weaponDamage;
    public ParticleSystem musFlash;
    public GameObject paintSplat;

    public AudioSource shotEffect;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false); //So the player does not start with a weapon
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1") && !playerMove.sprint)
        {
            Fire();
        }
        Debug.DrawRay(view.transform.position, view.transform.forward * projectileRange, Color.red);
	}

    public void Fire()
    {
        shotEffect.Play();
        musFlash.Play(); //Starts muzzle flash effect
        

        RaycastHit hitTarget;
        if (Physics.Raycast(view.transform.position, view.transform.forward, out hitTarget, projectileRange))
        {
            shootTarget target = hitTarget.transform.GetComponent<shootTarget>();

            GameObject paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal)); //Spawns the paint splat
            Destroy(paint, 20.0f); //Destroys paint after 20 secs

            if (target != null) //As long as there is a target..
            {
                target.takeDamage(weaponDamage); //inflict the damage
               
  
                if(target.targetHealth <= 0)
                {
                    Destroy(paint); //Destroys paint along with parent
                }
            }
        }



    }
}
