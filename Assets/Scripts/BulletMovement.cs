using UnityEngine;

public class BulletMovement : Movement
{
    protected Vector3 direction;


    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        this.direction.Normalize();
    }

    protected override void Move()
    {

        rb.linearVelocity = direction * movementSpeed;
    }
}
