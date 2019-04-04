using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    public AudioClip deathClip;
    public Slider healthSlider;
    public Image damageFlash;
    public float flashSpeed;
    public Color flashColor = new Color(1f, 0f, 0f);

    ShootingScript shooting;

    Animator anim;
    AudioSource audio;

    bool damaged;
    bool isdead;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        shooting = GetComponentInChildren<ShootingScript>();
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageFlash.color = flashColor;
        }

        else
        {
            damageFlash.color = Color.Lerp(damageFlash.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void Damage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        audio.Play();

        if(currentHealth <= 0 && !isdead)
        {
            Death();
        }
    }

    void Death()
    {
        isdead = true;

        anim.SetTrigger("Death");

        audio.clip = deathClip;
        audio.Play();

        shooting.enabled = false;
    }
}
