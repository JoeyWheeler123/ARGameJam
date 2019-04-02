using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float deathSpeed = 2.5f;
    public int scoreValue = 100;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem enemyParticles;
    CapsuleCollider collider;

    bool isDead;
    bool isSinking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        collider = GetComponent<CapsuleCollider>();
        enemyParticles = GetComponent<ParticleSystem>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * deathSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play();

        currentHealth -= amount;
        enemyParticles.transform.position = hitPoint;
        enemyParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        collider.isTrigger = true;
        anim.SetTrigger("Death");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
