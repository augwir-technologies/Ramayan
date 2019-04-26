using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleScript : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;

    public void Destruction()
    {
        foreach(Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();
            if(rb!= null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
