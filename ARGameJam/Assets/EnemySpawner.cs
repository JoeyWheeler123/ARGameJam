using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject ground;
    private GameObject GM;


    public int enemyCount;
    public int startEnemyCount;

    private List<GameObject> EnemysRef;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        GM = GameObject.FindGameObjectWithTag("GM");
        EnemysRef = GM.GetComponent<EnemyManager>().Enemys;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator SpawnEnemy()
    {
        
        while (enemyCount < startEnemyCount)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject tempEnemy = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
            tempEnemy.transform.parent = ground.transform;
            EnemysRef.Add(tempEnemy);
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
}
