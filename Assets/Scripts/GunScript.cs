using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int gunDamage;
    public Camera cam;
    public GameObject impactEffect;

    float nextTimeToShot;
    public float firerate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShot)
        {
            nextTimeToShot = Time.time + 1f / firerate;
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(gunDamage);
            }
            GameObject effect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(effect, 0.5f);
        }
    }
}