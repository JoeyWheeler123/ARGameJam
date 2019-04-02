using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public int bulletDamage = 50;
    public float timeShots = .2f;
    public float range = 100f;

    public float timer;
    Ray shotRay;
    RaycastHit shotHit;
    ParticleSystem shotParticles;
    int shootableMask;
    LineRenderer shotLine;
    AudioSource shotAudio;
    Light shotLight;
    float displayTime = .2f;

    private void Awake()
    {
        shotParticles =  GetComponent<ParticleSystem>();
        shootableMask = LayerMask.GetMask("Shootable");
        shotLine = GetComponent<LineRenderer>();
        shotAudio = GetComponent<AudioSource>();
        shotLight = GetComponent<Light>();

    }

    private void Update()
    {
        timer += Time.deltaTime;

        /*if(Input.GetButton("Fire1") && timer >= timeShots)
        {
            Shoot();
        }*/

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

    public void Shoot()
    {
        //timer = 0f;

        if (timer >= timeShots)
        {
            timer = 0f;

            shotAudio.Play();
            shotLight.enabled = true;

            shotParticles.Stop();
            shotParticles.Play();

            shotLine.enabled = true;
            shotLine.SetPosition(0, transform.position);
            shotRay.origin = transform.position;
            shotRay.direction = transform.forward;

            if (Physics.Raycast(shotRay, out shotHit, range, shootableMask))
            {
                //Debug.Log("Hit");

                EnemyHealthScript enemyHealth = shotHit.collider.GetComponent<EnemyHealthScript>();

                if (enemyHealth != null)
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
}
