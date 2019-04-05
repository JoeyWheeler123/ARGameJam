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
    private GameObject GM;
    public GameObject explosionEffect;
    
    private List<GameObject> EnemysRef;

 
    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem enemyParticles;
    CapsuleCollider collider;

    bool isDead;
    bool isSinking;

    // Start is called before the first frame update
    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        collider = GetComponent<CapsuleCollider>();
        //enemyParticles = GetComponent<ParticleSystem>();
        GM = GameObject.FindGameObjectWithTag("GM");
       
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    public void Update()
    {
        
        EnemysRef = GM.GetComponent<EnemyManager>().Enemys;
        if(currentHealth <= 0)
        {
            Death();
        }
        
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
//        enemyParticles.transform.position = hitPoint;
        //enemyParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        EnemysRef.Remove(gameObject);
        
        //return;
        // TAKE RETURN STATEMENT OUT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        isDead = true;

        collider.isTrigger = true;
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
       //anim.SetTrigger("Death");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        ScoreManager.score += scoreValue;
        EnemysRef.Remove(gameObject);
        Destroy(this.gameObject);
    }

    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
