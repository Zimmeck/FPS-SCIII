using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemigo : MonoBehaviour
{
    
    public int m_life = 100;
    NavMeshAgent nm;
    public Transform target;

    public enum AIState { idle, chasing, attack}

    public AIState aiState = AIState.idle;

    public float distanceTreshold;
    public float AttackTreshold;

    public GameObject arm1, arm2, arm3, arm4;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform; //GameManager.Instance.m_player;
        Debug.Log("Stop");
        nm.Stop();
        m_life = 100;
    }
    private void Update()
    {
        Death();

    
    }
    void Death()
    {
           if (m_life <= 0)
        {
            Score.score += 10;
           // GameManager.Instance.m_waves.EnemyDie();
            Destroy(this.gameObject);

        }
    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIState.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < distanceTreshold)
                    {
                        aiState = AIState.chasing;
                    }
                    Debug.Log("Stop");
                    nm.Stop();
                    //nm.SetDestination(transform.position);
                    break;
                case AIState.chasing:
                   dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distanceTreshold)
                    {
                        aiState = AIState.idle;
                    }
                    Debug.Log("SetDestination");
                    nm.SetDestination(target.position);
                    nm.Resume();
                    if (dist < AttackTreshold)
                    {
                        arm1.SetActive(true);
                        arm2.SetActive(true);
                        arm3.SetActive(true);
                        arm4.SetActive(true);
                        aiState = AIState.attack;
                     
                    }

                    break;

                case AIState.attack:
                    Debug.Log("SetDestination");
                    nm.SetDestination(target.position);
                    nm.Resume();
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > AttackTreshold)
                    {
                        arm1.SetActive(false);
                        arm2.SetActive(false);
                        arm3.SetActive(false);
                        arm4.SetActive(false);
                        aiState = AIState.chasing;
                      
                    }
                    break;
                default:
                    break;
            }           
            yield return new WaitForSeconds(1f);
        }
    }
}
