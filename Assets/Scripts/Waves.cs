using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject[] spawners;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[5];

        for(int i= 0; i< spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        timer = Time.deltaTime;
        if (timer == 60)
        {
            SpawnEnemy();
            timer = 0;
        }
        
    }
    void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(theEnemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }
}
