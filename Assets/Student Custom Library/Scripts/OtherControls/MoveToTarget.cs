using UnityEngine;
using UnityEngine.AI;

/* Move To Target
 * Moves objects towards a target using AI
 * Gleb - V1 - 01/21/25
 */
public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody targetRb;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player");
        }

        if (target != null)
        {
            targetRb = target.GetComponent<Rigidbody>();
            if (targetRb == null)
            {
                Debug.LogError("Target does not have a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogError("Target (Player) not found in the scene.");
        }

        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent == null)
            {
                Debug.LogError("NavMeshAgent component is missing from this GameObject.");
            }
        }
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    public void MoveTowardsTarget()
    {
        if (navMeshAgent != null && targetRb != null)
        {
            navMeshAgent.SetDestination(targetRb.transform.position);
        }
        else
        {
            Debug.LogWarning("Cannot move towards target. NavMeshAgent or target Rigidbody is null.");
        }
    }
}