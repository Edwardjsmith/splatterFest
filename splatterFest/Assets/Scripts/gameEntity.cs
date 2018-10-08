using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEntity : MonoBehaviour
{
    public float Health;
    protected float speed;
    protected RaycastHit hitTarget;

    protected float projectileRange = 200f;
    public float weaponDamage;
    public ParticleSystem musFlash;
    public GameObject paintSplat;
    public AudioSource shotEffect;
    protected float scaleLimit = 0.1f;

    public GameObject grenadeSpawn;
    public GameObject grenade;
    protected float grenadeTimer;
    protected float throwPower;

    protected void Fire()
    {
        Vector3 direction = Random.insideUnitCircle * scaleLimit;

        shotEffect.Play();
        musFlash.Play(); //Starts muzzle flash effect

        if (Physics.Raycast(transform.position, transform.forward + direction, out hitTarget))
        {
            UnityEngine.GameObject paint;
            if (!hitTarget.transform.GetComponent<gameEntity>())
            {
                paint = Instantiate(paintSplat, hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
                Destroy(paint, 20.0f);
            }
            else
            {
                hitTarget.transform.GetComponent<gameEntity>().takeDamage(1.0f);
            }
        }
    }

    public void throwGrenade()
    {
        GameObject gren = Instantiate(grenade, grenadeSpawn.transform.position, transform.rotation);

        gren.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwPower * Time.deltaTime);
    }


    public void takeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
