using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blast : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<shootTarget>())
        {
            other.GetComponent<shootTarget>().takeDamage(10.0f);
        }

        Destroy(gameObject, 0.5f);
        
    }

}
