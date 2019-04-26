using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestructible : MonoBehaviour
{
    public GameObject originalPrefab;
    public GameObject destructiblePrefab;
     
    public void SpawnDestructiblePrefab()
    {
        originalPrefab.SetActive(false);
        destructiblePrefab.SetActive(true);
        destructiblePrefab.GetComponent<DestructibleScript>().Destruction();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPrefab.SetActive(true);
        destructiblePrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnDestructiblePrefab();
        }
    }
}
