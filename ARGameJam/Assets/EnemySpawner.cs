using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public GameObject ground;
    private GameObject GM;
    public float planeSize;
    public float spawnTime;

    private GameObject tempPlane;

    public int enemyCount;
    public int startEnemyCount;
    private GameObject groundPlain;

    private List<GameObject> EnemysRef;
    private bool spawnEnemyRunning = false;
    
    public bool planeFound = false;
    
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        EnemysRef = GM.GetComponent<EnemyManager>().Enemys;
        //StartCoroutine(SpawnEnemy());
        
        StartCoroutine(GetDetectedPlane());
        groundPlain = GameObject.FindGameObjectWithTag("GroundPlain");
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.localScale += Vector3.one* Time.deltaTime;
        //ResetPlaneLocation();
        if (MaxEnemiesSpawned() == false && spawnEnemyRunning == false /*&& planeFound*/)
        {
           StartCoroutine(SpawnEnemy());

        }
        /*else
        {
            StopCoroutine(SpawnEnemy());
        }*/
        //Debug.Log(MaxEnemiesSpawned());
    }


    public IEnumerator SpawnEnemy()
    {
        spawnEnemyRunning = true;
                yield return new WaitForSeconds(spawnTime);
                int ran = Random.Range(0, 2);
                GameObject tempEnemy = Instantiate(EnemyPrefabs[ran], transform.position, Quaternion.identity);
                //tempEnemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                //tempEnemy.transform.parent = groundPlain.transform;
                //tempEnemy.GetComponentInChildren<MeshRenderer>().enabled = false;
                //tempEnemy.GetComponent<BoxCollider>().enabled = false;
                tempEnemy.transform.position = RandomPosition();
                EnemysRef.Add(tempEnemy);
        spawnEnemyRunning = false;
        //yield return new WaitForSeconds(0.1f);
        //enemyCount++;


    }
    
    public Vector3 RandomPosition()
    {
        Mesh planeMesh = ground.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = ground.transform.position.x - ground.transform.localScale.x * bounds.size.x * 0.5f;
        float maxX = ground.transform.position.x + ground.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = ground.transform.position.z - ground.transform.localScale.z * bounds.size.z * 0.5f;
        float maxZ = ground.transform.position.z + ground.transform.localScale.z * bounds.size.z * 0.5f;


        Vector3 newVec = new Vector3(Random.Range (minX, maxX),
            ground.transform.position.y+ 0.02f,
            Random.Range (minZ, maxZ));
        //print((minX));
        //print((minZ));

        return newVec;
        
        
        
    }

    public IEnumerator GetDetectedPlane()
    {
        yield return new WaitForSeconds(0.2f);

        tempPlane = GameObject.Find("New Game Object").transform.GetChild(0).gameObject;
        ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = new Vector3(tempPlane.transform.position.x, tempPlane.transform.position.y, tempPlane.transform.position.z + planeSize*5);
        ground.transform.localScale = new Vector3(planeSize,planeSize,planeSize);
        ground.GetComponent<MeshRenderer>().enabled = false;
        //ground.transform.parent = tempPlane.transform.parent;

    }

    public void ResetPlaneLocation()
    {
       
        tempPlane.transform.position = Vector3.zero;   
        ground.transform.localPosition = new Vector3(tempPlane.transform.position.x, tempPlane.transform.position.y, tempPlane.transform.position.z + planeSize*5);
        planeFound = true;
    }

    public bool MaxEnemiesSpawned()
    {
        bool temp;
        if (EnemysRef.Count < startEnemyCount)
        {
            temp = false;
        }
        else
        {
            temp = true;
        }

        return temp;


    }
}
