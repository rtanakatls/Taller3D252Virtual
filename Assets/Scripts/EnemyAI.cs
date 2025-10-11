using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent agent;
    [SerializeField] private float followDistance;
    private Vector3 targetPosition;
    [SerializeField] private LayerMask lookLayerMask;
    [SerializeField] private float angle;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= followDistance)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit, followDistance, lookLayerMask, QueryTriggerInteraction.UseGlobal))
                {
                    Vector3 a = (target.position - transform.position).normalized;
                    Vector3 b = transform.forward.normalized;

                    if (!hit.collider.gameObject.CompareTag("Terrain") && Vector3.Angle(a, b) <= angle)
                    {
                        targetPosition = target.position;
                    }
                }
            }

            agent.SetDestination(targetPosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.color = Color.yellow;
        Vector3 direction = transform.forward.normalized;
        direction = Quaternion.AngleAxis(angle, transform.up) * direction;
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * followDistance);
        Gizmos.color = Color.yellow;
        direction = transform.forward.normalized;
        direction = Quaternion.AngleAxis(-angle, transform.up) * direction;
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * followDistance);
    }
}
