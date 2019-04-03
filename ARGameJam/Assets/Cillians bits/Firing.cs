using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    bool shooting;
    public GameObject player, bullet;
    public float fireRange;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(Input.GetKeyDown(KeyCode.Mouse1))
            {
            Debug.Log("Click");
            shootPlayer();
            }*/
        Fire();

    }
    

    /*private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.tag == "Player")
       {
            Debug.Log("Collison");
           GetComponent<Arrive>().enabled = false;
            GetComponent<Boid>().enabled = false;
            shooting = true;
       }
       
 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Arrive>().enabled = true;
            GetComponent<Boid>().enabled = true;
            
        }
    }*/

    IEnumerator shootPlayer()
    {
        while (true) {
            Debug.Log("Start");
            if (shooting) {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(2.0f);            
        }
        
    }

    public float DistanceToPlayer()
    {
       return Vector3.Distance(transform.position, player.transform.position);

    }

    public void Fire()
    {
        if (DistanceToPlayer() < fireRange)
        {
            GetComponent<Arrive>().enabled = false;
            GetComponent<Boid>().enabled = false;
            shooting = true;
        }
        else
        {
            GetComponent<Arrive>().enabled = true;
            GetComponent<Boid>().enabled = true;
            shooting = false;
        }
        
    }
}
