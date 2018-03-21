using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintSplat : MonoBehaviour {

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            transform.SetParent(collision.transform); //Sets parent so paint splats will be destroyed when new parent is
        
    }

}
