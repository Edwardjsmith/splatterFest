using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healEntity : MonoBehaviour {

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.GetComponent<gameEntity>())
        {
            collision.gameObject.GetComponent<gameEntity>().Health++;

            if(collision.gameObject.GetComponent<gameEntity>().Health >= 10)
            {
                collision.gameObject.GetComponent<gameEntity>().Health = 10;
            }
        }
    }


}
