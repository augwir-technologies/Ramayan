using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestructible : MonoBehaviour
{
    public GameObject originalPrefab;
    public GameObject destructiblePrefab;
    public GameObject firePrefab;
    public GameObject smokePrefab;
    public GameObject dustPrefab;


    IEnumerator SpawnDestructiblePrefab()
    {
        yield return new WaitForSeconds(1);
        originalPrefab.SetActive(false);
        destructiblePrefab.SetActive(true);
        firePrefab.SetActive(true);
        smokePrefab.SetActive(true);
        dustPrefab.SetActive(true);
        destructiblePrefab.GetComponent<DestructibleScript>().Destruction();

        yield return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPrefab.SetActive(true);
        destructiblePrefab.SetActive(false);
        firePrefab.SetActive(false);
        smokePrefab.SetActive(false);
        dustPrefab.SetActive(false);
    }

    public void SpawnFireEffect()
    {
        originalPrefab.SetActive(true);
        destructiblePrefab.SetActive(false);
        firePrefab.SetActive(true);
        smokePrefab.SetActive(true);
        dustPrefab.SetActive(false);

        StartCoroutine("SpawnDestructiblePrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFireEffect();
        }
    }
}
