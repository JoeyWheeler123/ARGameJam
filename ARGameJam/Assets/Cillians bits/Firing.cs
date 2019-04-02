using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{

    public GameObject player, bullet;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(Input.GetKeyDown(KeyCode.Mouse1))
            {
            Debug.Log("Click");
            shootPlayer();
            }*/

    }
    

    private void OnTriggerEnter(Collider other)
    {
       // if (other.gameObject.tag == "Player")
       // {
            Debug.Log("Collison");
            Destroy(GetComponent<Arrive>());
            Destroy(GetComponent<Boid>());
          
            StartCoroutine(shootPlayer());
       // }

        
    }

    IEnumerator shootPlayer()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Fire");
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
