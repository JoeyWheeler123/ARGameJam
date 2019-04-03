using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    bool shooting;
    public GameObject player, bullet;
   

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

    }
    

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.tag == "Player")
       {
            Debug.Log("Collison");
            Destroy(GetComponent<Arrive>());
            Destroy(GetComponent<Boid>());
            shooting = true;
       }

        
    }

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
}
