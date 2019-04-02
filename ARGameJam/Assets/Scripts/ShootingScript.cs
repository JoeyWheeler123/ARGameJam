using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public int bulletDamage = 50;
    public float timeShots = .2f;
    public float range = 100f;

    float timer;
    Ray shotRay;
    RaycastHit shotHit;
    //ParticleSystem shotParticles;
    int shootableMask;
    LineRenderer shotLine;
    AudioSource shotAudio;
    Light shotLight;
    float displayTime = .2f;

    private void Awake()
    {
        //shotParticles =  GetComponent<ParticleSystem>();
        shootableMask = LayerMask.GetMask("Shootable");
        shotLine = GetComponent<LineRenderer>();
        shotAudio = GetComponent<AudioSource>();
        shotLight = GetComponent<Light>();

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Shoot") && timer >= timeShots)
        {
            Shoot();
        }

        if(timer >= timeShots * displayTime)
        {
            DisableEffects();
        }
    }

    void DisableEffects()
    {
        shotLine.enabled = false;
        shotLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0;

        shotAudio.Play();
        shotLight.enabled = true;

        //shotParticles.Stop();
        //shotPrticles.Play();

        shotLine.enabled = true;
        shotLine.SetPosition(0, transform.position);
        shotRay.origin = transform.position;
        shotRay.direction = transform.forward;

        if(Physics.Raycast(shotRay, range, shootableMask))
        {
            EnemyHealthScript enemyHealth = shotHit.collider.GetComponent<EnemyHealthScript>();

            if(enemyHealth !=null)
            {
                enemyHealth.TakeDamage(bulletDamage, shotHit.point);
            }
            shotLine.SetPosition(1, shotHit.point);
        }
        else
        {
            shotLine.SetPosition(1, shotRay.origin + shotRay.direction * range);
        }
    }
}
