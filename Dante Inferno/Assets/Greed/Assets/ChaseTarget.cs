using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ChaseTarget : MonoBehaviour
{
    public Transform target; 
    public float soundTriggerDistance = 5f;
    public AudioClip closeSound;
    public AudioClip farSound;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private bool isClose = false;
    private bool isChasing = false;
    private float chaseDuration = 12f; 
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (target != null && isChasing)
        {
            agent.SetDestination(target.position);
            
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= soundTriggerDistance)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = closeSound;
                    audioSource.Play();
                }

                isClose = true;
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = farSound;
                    audioSource.Play();
                }

                isClose = false;

            }
        }
    }
    
    // Call this method to start the chase
    public void StartChase()
    {
        if (!isChasing)
        {
            isChasing = true;
            agent.isStopped = false;
            StartCoroutine(StopChaseAfterTime(chaseDuration));
        }
    }

    
    private IEnumerator StopChaseAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        // Stop chasing and disable the NavMeshAgent's movement
        isChasing = false;
        agent.isStopped = true;
    }

}