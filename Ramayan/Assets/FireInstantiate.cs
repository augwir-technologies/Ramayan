using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInstantiate : MonoBehaviour
{
    public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 5);
            Debug.Log(hit.transform.name);
            Instantiate(Fire, hit.transform.position, hit.transform.rotation);
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Instantiate(Fire, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
    //    Debug.Log(collision.gameObject.name);
    //}
}
