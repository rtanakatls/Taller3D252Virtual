using UnityEngine;

public class UnitMovement : Movement
{
    [SerializeField] protected Vector3 direction;

    public Vector3 Direction { get { return direction; } }

    protected override void Init()
    {
        base.Init();
        direction.Normalize();
    }

    protected override void Move()
    {

        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
    }
}
