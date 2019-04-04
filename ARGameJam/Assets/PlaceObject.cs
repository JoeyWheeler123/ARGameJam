using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{

    //public bool planeFound;
    private GameObject GM;
    private List<GameObject> EnemysRef;
    private bool planeGot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        EnemysRef = GM.GetComponent<EnemyManager>().Enemys;
        planeGot = GetComponent<EnemySpawner>().planeFound;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(planeGot);
        if (GetComponent<EnemySpawner>().planeFound)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void PlaceCharacter()
    {
        //transform.localPosition = Vector3.zero;
        
    }
}
