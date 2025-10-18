using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform head;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h=Input.GetAxisRaw("Horizontal");
        float v=Input.GetAxisRaw("Vertical");
        transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), 0);

        Vector3 rotation = new Vector3(head.eulerAngles.x - Input.GetAxis("Mouse Y"), 0, 0);
        Vector3.ClampMagnitude(rotation, 90);
        head.localRotation=Quaternion.Euler(rotation);

        rb.linearVelocity = transform.forward * v*speed + transform.right * h*speed;
    }

}
