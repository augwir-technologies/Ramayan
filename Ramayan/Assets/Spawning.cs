using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject Enemies;
    GameObject[] SpawnEnemies;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnEnemies = GameObject.FindGameObjectsWithTag("Respawn");
            index = Random.Range(0, SpawnEnemies.Length);
            Instantiate(Enemies, SpawnEnemies[index].transform.position, SpawnEnemies[index].transform.rotation);
        }   
    }
}
