using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float mass = 1f;
    public float gravitation = -9.82f;
    private Vector2 velocity = Vector2.zero;
    public Vector2 startVelocity;
    public Vector2 startPosition = new Vector2(0,4);
    public float bounciness = 0.5f;
    public float frictionCoefficient = 0.2f;
    public float drag = 0.05f;
    public bool isLaunched;
    
    private void FixedUpdate()
    {
        if (isLaunched)
        {
            transform.position += (Vector3)(velocity) * Time.fixedDeltaTime;
            
            if (transform.position.y < transform.localScale.y / 2)
            {
                Collision();
            }
            
            AirResistance();
            float forceX = AirResistance() * -velocity.normalized.x;
            float forceY = AirResistance() * -velocity.normalized.y + Gravitation();
            if (transform.position.y < transform.localScale.y / 2 * 1.05f)
            {
                if (Mathf.Abs(velocity.x) > 0.05)
                {
                    forceX -= Friction() * Mathf.Sign(velocity.x);
                }
                else velocity.x = 0;
            }
            velocity += new Vector2(forceX, forceY) / mass * Time.fixedDeltaTime;
            
        }
    }
    private void Update()
    {
        if (!isLaunched)
        {
            transform.position = startPosition;
        }
    }
    public void Launch()
    {
        transform.position = startPosition;
        velocity = startVelocity;
        isLaunched = true;
    }
    public void ResetBall()
    {
        isLaunched = false;
        transform.position = startPosition;
    }
    private float Gravitation()
    {
        return gravitation * mass;
    }

    private void Collision()
    {
        transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, transform.position.z);
        velocity.y = -velocity.y * bounciness;
    }

    private float Friction()
    {
        return frictionCoefficient * Mathf.Abs(gravitation) * mass;
    }

    private float AirResistance()
    {
        float area = Mathf.PI * (transform.localScale.y / 2) * (transform.localScale.y / 2);
        return (drag * area * velocity.sqrMagnitude) / 2;
    }
}
