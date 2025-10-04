using System.Collections;
using UnityEngine;

public class UnitShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float shootCooldown = 0.5f;
    private UnitMovement unitMovement;

    private void Awake()
    {
        unitMovement = GetComponent<UnitMovement>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.GetComponent<BulletMovement>().SetDirection(unitMovement.Direction);
            yield return new WaitForSeconds(shootCooldown);
        }
    }

}
