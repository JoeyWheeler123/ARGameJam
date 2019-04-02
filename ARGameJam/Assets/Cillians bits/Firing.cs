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
        
            Debug.Log("Collison");
            Destroy(GetComponent<Arrive>());
        StartCoroutine(shootPlayer());

        
    }

    IEnumerator shootPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
