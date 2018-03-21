using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    
    public GameObject blastEffect;
    public GameObject blastRadius;

    private void OnCollisionEnter(Collision other)
    {
        GameObject go = Instantiate(blastEffect, gameObject.transform);
        GameObject go2 = Instantiate(blastRadius, gameObject.transform);
                
        Destroy(gameObject, 0.1f);
    }
       
    
}
