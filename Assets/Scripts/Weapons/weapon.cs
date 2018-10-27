﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public float damage = 10f;
    public float range = 200f;
    public float fireRate = 5f;
    public float impactForce = 200f;

    public string currentAmmoType = "AR";

    public Camera fpsCam;
    public GameObject fpsController;
    public GameObject gameManager;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject blood;
    public GameObject bulletHole;

    private float fireTimer = 100f;
    private Vector3 localPos = new Vector3();
    private Quaternion localRot = new Quaternion();

    void Start()
    {
        localPos = gameObject.transform.localPosition;
        localRot = gameObject.transform.localRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        fireTimer += Time.deltaTime;

		if(Input.GetButton("Fire1") && fireTimer >= 1/fireRate){
            Shoot();
            fireTimer = 0;
        }
        ADS();
	}
    void ADS()
    {
        Vector3 myPostion = gameObject.transform.localPosition;
        float myFOV = fpsCam.GetComponent<Camera>().fieldOfView;
        if(Input.GetButton("Fire2")){
            gameObject.transform.localPosition = LerpVector(myPostion, new Vector3(0,-.216f,.7f),.2f);
            gameObject.transform.localRotation = Quaternion.LookRotation(new Vector3(0,0,-1));
            fpsCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(myFOV,30,.2f);
        }else{
            gameObject.transform.localPosition = LerpVector(myPostion, localPos, .2f);
            gameObject.transform.localRotation = localRot;
            fpsCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(myFOV,60,.2f);
        }
    }
    void Shoot()
    {

        if(gameManager.GetComponent<GameManager>().CheckAmmo(currentAmmoType) > 0)
        {
            muzzleFlash.Play();
            gameManager.GetComponent<GameManager>().AddAmmo(currentAmmoType, -1);
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                GameObject myImpact = impactEffect;
                if (target != null)
                {
                    target.TakeDamage(damage);
                    myImpact = blood;
                }
                else
                {
                    GameObject bh = Instantiate(bulletHole, hit.point + (hit.normal * .01f), Quaternion.LookRotation(hit.normal));
                    Destroy(bh, 10);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impact = Instantiate(myImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1);
            }
        }

        
        
    }
    Vector3 LerpVector(Vector3 vec1, Vector3 vec2, float amount)
    {
        amount = Mathf.Clamp(amount, 0f, 1f);

        float x = Mathf.Lerp(vec1.x,vec2.x,amount);
        float y = Mathf.Lerp(vec1.y,vec2.y,amount);
        float z = Mathf.Lerp(vec1.z,vec2.z,amount);

        return new Vector3(x,y,z);
    }
}
