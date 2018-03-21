using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTarget : MonoBehaviour {

    public float targetHealth;
	
	public void takeDamage(float amount)
    {
        targetHealth -= amount;

        if(targetHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
