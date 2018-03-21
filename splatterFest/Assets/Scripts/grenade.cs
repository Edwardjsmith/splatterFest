using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    
    public GameObject blastEffect;
    public GameObject blastRadius;

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        GameObject go = Instantiate(blastEffect, contact.point, Quaternion.FromToRotation(Vector3.up, contact.normal));
        go.transform.localScale = new Vector3(1.2f, 0.1f, 1.2f);
        


        GameObject go2 = Instantiate(blastRadius, contact.point, Quaternion.FromToRotation(Vector3.up, contact.normal));
                
        Destroy(gameObject);
    }
       
    
}
