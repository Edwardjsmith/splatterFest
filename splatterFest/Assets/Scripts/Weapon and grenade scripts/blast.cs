using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blast : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<gameEntity>())
        {
            other.GetComponent<gameEntity>().takeDamage(10.0f);
        }

        Destroy(gameObject, 0.5f);
        
    }

}
