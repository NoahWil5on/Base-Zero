using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{

    public float damage = 10f;
    public float range = 200f;
    public float fireRate = 5f;
    public float impactForce = 200f;
    public int magSize = 10;
    public int currentAmmoCount = 30;
    public float reloadTime = 1.0f;
    public int adsZoom = 30;
    public float adsAccuracy = 1000.0f;
    public float accuracy = 100.0f;
    public float recoil = 1.5f;
    public int bulletCount = 1;
    public bool semiAuto = false;

    private float currentAccuracy = 1.0f;
    private bool hasFired = false;
    private bool willReset1 = false;
    private bool willReset2 = false;
    private bool hasReloaded = true;

    public string currentAmmoType = "AR";
    public string scopeName = "scope_defualt";

    public Camera fpsCam;
    public GameObject fpsController;
    public GameObject gameManager;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject blood;
    public GameObject bulletHole;
    private GameObject scopeImage;
    public GameObject weaponCamera;

    public AudioSource fireSound;
    public Animator animator;
    public Animator secondMotionAnimator;

    private float fireTimer = 100f;
    private float reloadTimer = 100f;

    private Vector3 localPos = new Vector3();
    private Quaternion localRot = new Quaternion();

    private int myIterations = 0;

    private bool[] myUpgrades = {false, false, false, false};

    void Start()
    {
        if(currentAmmoCount > magSize) currentAmmoCount = magSize;
        gameManager = GameObject.FindGameObjectWithTag("gm");
        GameObject[] scopeImages = GameObject.FindGameObjectsWithTag("scopeImage");
        for(int i = 0; i < scopeImages.Length; i++){
            if(scopeImages[i].name == scopeName){
                scopeImage = scopeImages[i];
            }
        }

        FindStats(this.gameObject);
        currentAccuracy = accuracy;
    }
    void FindStats(GameObject objToSearch){
        if(myIterations > 30) return;

        myIterations++;
        Transform[] children = this.GetComponentsInChildren<Transform>();

        for(int i = 0; i < children.Length; i++){
            if(children[i].GetComponent<stock>() != null){
                if(children[i].GetComponent<stock>().upgrade && myUpgrades[0]){
                    print("upgraded");
                }else if(children[i].GetComponent<stock>().upgrade){
                    children[i].gameObject.SetActive(false);
                }

                if(!children[i].GetComponent<stock>().upgrade && !myUpgrades[0]){
                    print("unUpgraded");
                }else if(!children[i].GetComponent<stock>().upgrade){
                    children[i].gameObject.SetActive(false);
                }
            }else if(children[i].GetComponent<magazine>() != null){
                if(children[i].GetComponent<magazine>().upgrade && myUpgrades[0]){
                    print("upgraded");
                }else if(children[i].GetComponent<magazine>().upgrade){
                    children[i].gameObject.SetActive(false);
                }

                if(!children[i].GetComponent<magazine>().upgrade && !myUpgrades[0]){
                    print("unUpgraded");
                }else if(!children[i].GetComponent<magazine>().upgrade){
                    children[i].gameObject.SetActive(false);
                }
            }else if(children[i].GetComponent<scope>() != null){
                if(children[i].GetComponent<scope>().upgrade && myUpgrades[0]){
                    print("upgraded");
                }else if(children[i].GetComponent<scope>().upgrade){
                    children[i].gameObject.SetActive(false);
                }

                if(!children[i].GetComponent<scope>().upgrade && !myUpgrades[0]){
                    print("unUpgraded");
                }else if(!children[i].GetComponent<scope>().upgrade){
                    children[i].gameObject.SetActive(false);
                }
            }else if(children[i].GetComponent<barrel>() != null){
                if(children[i].GetComponent<barrel>().upgrade && myUpgrades[0]){
                    print("upgraded");
                }else if(children[i].GetComponent<barrel>().upgrade){
                    children[i].gameObject.SetActive(false);
                }

                if(!children[i].GetComponent<barrel>().upgrade && !myUpgrades[0]){
                    print("unUpgraded");
                }else if(!children[i].GetComponent<barrel>().upgrade){
                    children[i].gameObject.SetActive(false);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        reloadTimer += Time.deltaTime;

        if (fireTimer >= 1 / (fireRate * 2))
        {
            secondMotionAnimator.SetBool("firing", false);
        }
        if (reloadTimer < reloadTime)
        {
            hasReloaded = false;
            float myFOV = fpsCam.GetComponent<Camera>().fieldOfView;
            animator.SetBool("ads", false);
            fpsCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(myFOV, 60, .2f);
            return;
        }
        else if(!Input.GetButton("Fire2")){
            hasReloaded = true;
        }
        animator.SetBool("reloading", false);
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
            return;
        }
        if (Input.GetButton("Fire1") && fireTimer >= 1 / fireRate && reloadTimer > reloadTime + 0.3f)
        {
            if(semiAuto && hasFired) return;
            Shoot();
            fireTimer = 0;
        }
        if( fireTimer >= 1 / fireRate){
            willReset1 = true;
        }
        if(Input.GetButtonUp("Fire1")){
            willReset2 = true;
        }
        if(willReset1 && willReset2) hasFired = false;
        if(hasReloaded) ADS();
    }
    void ADS()
    {
        float myFOV = fpsCam.GetComponent<Camera>().fieldOfView;
        if (Input.GetButton("Fire2"))
        {
            currentAccuracy = adsAccuracy;
            if(scopeImage){
                scopeImage.GetComponent<Image>().enabled = true;
                weaponCamera.SetActive(false);
            }
            animator.SetBool("ads", true);
            fpsCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(myFOV, adsZoom, .2f);
        }
        else
        {
            currentAccuracy = accuracy;
            if(scopeImage){
                scopeImage.GetComponent<Image>().enabled = false;
                weaponCamera.SetActive(true);
            }
            animator.SetBool("ads", false);
            fpsCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(myFOV, 60, .2f);
        }
    }
    void Shoot()
    {
        if (currentAmmoCount <= 0) return;
        hasFired = true;
        willReset1 = false;
        willReset2 = false;
        secondMotionAnimator.SetBool("firing", true);

        muzzleFlash.Play();
        fpsController.GetComponent<FirstPersonController>().m_MouseLook.m_CameraTargetRot *= Quaternion.Euler (-recoil, 0f, 0f);
        //fpsCam.transform.Rotate(fpsCam.transform.right, 5.0f);
        fireSound.GetComponent<AudioSource>().Play(0);
        currentAmmoCount--;
        RaycastHit hit;

        for(int i = 0; i < bulletCount; i++){
            Vector3 shootDirection = fpsCam.transform.forward;
            shootDirection.x += Random.Range(-1000,1000) / (currentAccuracy * 1000.0f);
            shootDirection.y += Random.Range(-1000,1000) / (currentAccuracy * 1000.0f);
            shootDirection.z += Random.Range(-1000,1000) / (currentAccuracy * 1000.0f);

            shootDirection.Normalize();

            if (Physics.Raycast(fpsCam.transform.position, shootDirection, out hit, range))
            {
                DoBullet(hit);
            }
        }
    }
    void DoBullet(RaycastHit hit){
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
    void Reload()
    {
        if (currentAmmoCount == magSize) return;
        int ammoCount = gameManager.GetComponent<GameManager>().CheckAmmo(currentAmmoType);
        if (ammoCount == 0) return;

        if(scopeImage){
            scopeImage.GetComponent<Image>().enabled = false;
            weaponCamera.SetActive(true);
        }

        animator.SetBool("reloading", true);

        int ammoChange = Mathf.Min((magSize - currentAmmoCount), ammoCount);
        currentAmmoCount += ammoChange;
        gameManager.GetComponent<GameManager>().AddAmmo(currentAmmoType, -ammoChange);

        reloadTimer = 0;
    }

}
