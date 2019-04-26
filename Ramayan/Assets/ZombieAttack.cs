using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public GameObject Player;
    Vector3 offset;
    float movespeed = 1f;
    float rotatespeed = 10f;
    public NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(Player.transform.position * 2);
        offset = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(offset, Vector3.up * rotatespeed * Time.deltaTime);
        transform.rotation = rotation;

        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance < 2)
        {
            movespeed = 0;
            Debug.Log(movespeed + "this is the move speed");
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
