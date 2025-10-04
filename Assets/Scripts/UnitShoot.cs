using System.Collections;
using UnityEngine;

public class UnitShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float shootCooldown = 0.5f;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float radius;

    private void Awake()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetLayerMask);
            if (colliders.Length > 0)
            {
                Vector3 direction = colliders[0].transform.position - transform.position;
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(direction);
            }
            yield return new WaitForSeconds(shootCooldown);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
