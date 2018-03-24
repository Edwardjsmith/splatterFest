using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEntity : MonoBehaviour
{
    public float Health;
    protected float speed;



    

    public void takeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

}
