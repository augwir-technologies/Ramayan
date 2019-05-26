using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{

    public GameObject HealthBar;
    GameObject EnemyBoss;
    public float health;
    GameObject Player, BossEnemy;
    Vector3 offset;
    float movespeed = 10f;
    float rotatespeed = 10f;
    public NavMeshAgent agent;
    Animator BossAnim;
    public float WalkDis, ComboDis, AttackDis; 
    // Start is called before the first frame update
    void Start()
    {
        BossAnim = GetComponent<Animator>();
        BossAnim.SetBool("AngryRoar", true);
        agent.speed = 0;
        health = 1;
        Player = GameObject.FindWithTag("Player");
        

    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(Player.transform.position);
        offset = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(offset, Vector3.up * rotatespeed * Time.deltaTime);
        transform.rotation = rotation;

        float distance = Vector3.Distance(Player.transform.position, transform.position);

        bool walktrue = ToWalk.agentspeed;
        Debug.Log(walktrue);
        Debug.Log("Distance" + distance);
        if (distance > WalkDis && walktrue)
        {
            Debug.Log(distance + "greater than 7");
            agent.speed = 2;
            BossAnim.SetBool("AngryRoar", false);
            BossAnim.SetBool("ComboForward", false);
            BossAnim.SetBool("IdleAttack", false);

            BossAnim.SetBool("Walk", true);
        }
        if(distance <= WalkDis && distance > ComboDis && walktrue)
        {
            agent.speed = 2;
            BossAnim.SetBool("Walk", false);
            BossAnim.SetBool("IdleAttack", false);

            BossAnim.SetBool("ComboForward", true);
        }
        if (distance < AttackDis && walktrue)
        {
            agent.speed = 0;
            BossAnim.SetBool("IdleAttack", true);
            BossAnim.SetBool("ComboForward", false);
            BossAnim.SetBool("Walk", false);
            BossAnim.SetBool("AngryRoar", false);
        }

  

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ClubMace"))
        {
            health -= 0.5f;
            Debug.Log(health);
            if (health < 10)
            {
                HealthBar.transform.localScale = new Vector3(health, 0.30396f, 1);
            }

            if (health == 0)
            {
                agent.speed = 0;
                BossAnim.SetBool("Death", true);
                BossAnim.SetBool("IdleAttack", false);
                BossAnim.SetBool("ComboForward", false);
                BossAnim.SetBool("Walk", false);
                BossAnim.SetBool("AngryRoar", false);
                StartCoroutine("DestroyBoss");
                EnemyBoss = gameObject;
                //EnemyBoss.GetComponent<CapsuleCollider>().enabled = false;
            }

        }
    }

    IEnumerator DestroyBoss()
    {
        yield return new WaitForSeconds(4f);
        Destroy(EnemyBoss);
    }

}
