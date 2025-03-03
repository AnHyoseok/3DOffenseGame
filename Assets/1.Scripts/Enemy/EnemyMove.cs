
using UnityEngine;
using UnityEngine.AI;

namespace IdleGame
{

    public class EnemyMove : MonoBehaviour
    {
        NavMeshAgent agent;
        Transform target;
        [SerializeField] float speed = 1f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("NavMeshAgent component not found!");
                return;
            }

            agent.updateRotation = false;
            agent.updateUpAxis = false;

            HeroHealth heroHealth = FindAnyObjectByType<HeroHealth>();
            if (heroHealth != null)
            {
                target = heroHealth.transform;
            }
            else
            {
                Debug.LogError("heroHealth object not found!");
            }

          
        }

        void Update()
        {
            if (target != null && agent != null)
            {
                agent.speed = speed;
                agent.SetDestination(target.position);

              
            }
        }
    }
}

