
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float distance;
    private bool isLockOn;
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, distance, targetLayerMask, QueryTriggerInteraction.UseGlobal))
        {
            isLockOn = true;
            if(Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            isLockOn = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (isLockOn)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, transform.up * distance);
    }
}
