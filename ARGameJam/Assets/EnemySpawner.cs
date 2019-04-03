using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject ground;
    private GameObject GM;
    public float planeSize;

    private GameObject tempPlane;

    public int enemyCount;
    public int startEnemyCount;
    private GameObject groundPlain;

    private List<GameObject> EnemysRef;
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        GM = GameObject.FindGameObjectWithTag("GM");
        EnemysRef = GM.GetComponent<EnemyManager>().Enemys;
        StartCoroutine(GetDetectedPlane());
        groundPlain = GameObject.FindGameObjectWithTag("GroundPlain");
    }

    // Update is called once per frame
    void Update()
    {
        ResetPlaneLocation();
    }


    public IEnumerator SpawnEnemy()
    {
        
        while (enemyCount < startEnemyCount)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject tempEnemy = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
            tempEnemy.transform.parent = groundPlain.transform;
            //tempEnemy.GetComponent<MeshRenderer>().enabled = false;
            //tempEnemy.GetComponent<BoxCollider>().enabled = false;
            EnemysRef.Add(tempEnemy);
            enemyCount++;
        }
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
        print((minX));
        print((minZ));

        return newVec;
        
        
        
    }

    public IEnumerator GetDetectedPlane()
    {
        yield return new WaitForSeconds(0.2f);

        tempPlane = GameObject.Find("New Game Object").transform.GetChild(0).gameObject;
        ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = tempPlane.transform.position;
        ground.transform.localScale = new Vector3(planeSize,planeSize,planeSize);
        ground.GetComponent<MeshRenderer>().enabled = false;
        //ground.transform.parent = tempPlane.transform.parent;

    }

    public void ResetPlaneLocation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ground.transform.localPosition = Vector3.zero;
        }
        
        

    }
}
