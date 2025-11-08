
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float distance;
    [SerializeField] private GameObject decal;
    private RaycastHit hit;
    private bool isLockOn;
    void Update()
    {
        isLockOn = Physics.Raycast(transform.position, transform.up, out hit, distance, targetLayerMask, QueryTriggerInteraction.UseGlobal);
       
        if (Input.GetMouseButtonDown(0))
        {
            if (isLockOn)
            {
                Destroy(hit.collider.gameObject);
            }
            else
            {
                RaycastHit missedHit;
                if(Physics.Raycast(transform.position,transform.up,out missedHit, distance))
                {
                    GameObject obj = Instantiate(decal, missedHit.point + missedHit.normal * 0.1f,Quaternion.identity);
                    obj.transform.forward = transform.up;
                }
            }
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
