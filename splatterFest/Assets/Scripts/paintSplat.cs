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
        if(collision != null)
        {
            transform.SetParent(collision.transform);
        }
    }

}
