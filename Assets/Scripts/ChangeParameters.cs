using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParameters : MonoBehaviour
{
    public BallPhysics ballPhysics;
    public InputField startPosX;
    public InputField startPosY;
    public InputField size;
    public InputField startVelX;
    public InputField startVelY;
    public InputField mass;
    public InputField gravity;
    public InputField bounciness;
    public InputField friction;
    public InputField drag;

    private void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        startPosX.text = ballPhysics.startPosition.x.ToString();
        startPosY.text = ballPhysics.startPosition.y.ToString();
        startVelX.text = ballPhysics.startVelocity.x.ToString();
        startVelY.text = ballPhysics.startVelocity.y.ToString();
        size.text = ballPhysics.transform.localScale.y.ToString();
        mass.text = ballPhysics.mass.ToString();
        gravity.text = ballPhysics.gravitation.ToString();
        bounciness.text = ballPhysics.bounciness.ToString();
        friction.text = ballPhysics.frictionCoefficient.ToString();
        drag.text = ballPhysics.drag.ToString();
    }
    public void ChangeStartPosX()
    {
        if (startPosX != null)
        {
            if (startPosX.text != null)
            {
                ballPhysics.startPosition.x = float.Parse(startPosX.text);
            }
        }
    }
    public void ChangeStartPosY()
    {
        if (startPosY != null)
        {
            if (startPosY.text != null)
            {
                if (ballPhysics.transform.localScale.y / 2 >= float.Parse(startPosY.text))
                {
                    ballPhysics.transform.position = new Vector3(ballPhysics.transform.position.x, (ballPhysics.transform.localScale.y / 2) + 0.01f, ballPhysics.transform.position.z);
                    startPosY.text = ballPhysics.transform.position.y.ToString();
                    ballPhysics.startPosition.y = ballPhysics.transform.position.y;
                }
                else ballPhysics.startPosition.y = float.Parse(startPosY.text);
            }
        }
    }
    public void ChangeSize()
    {
        if (size != null)
        {
            if (size.text != null)
            {
                if ((Vector3.one * float.Parse(size.text)).y / 2 >= ballPhysics.transform.position.y) 
                {
                    ballPhysics.transform.position = new Vector3(ballPhysics.transform.position.x, ((Vector3.one * float.Parse(size.text)).y / 2) + 0.01f, ballPhysics.transform.position.z);
                    startPosY.text = ballPhysics.transform.position.y.ToString();
                    ballPhysics.startPosition.y = ballPhysics.transform.position.y;
                }
                ballPhysics.transform.localScale = Vector3.one * float.Parse(size.text);
            }
        }
    }
    public void ChangeStartVelX()
    {
        if (startVelX != null)
        {
            if (startVelX.text != null)
            {
                ballPhysics.startVelocity.x = float.Parse(startVelX.text);
            }
        }
    }
    public void ChangeStartVelY()
    {
        if (startVelY != null)
        {
            if (startVelY.text != null)
            {
                ballPhysics.startVelocity.y = float.Parse(startVelY.text);
            }
        }
    }
    public void ChangeMass()
    {
        if (mass != null)
        {
            if (mass.text != null)
            {
                float massF = float.Parse(mass.text);
                if (massF <= 0)
                {
                    massF = 0.001f;
                    mass.text = massF.ToString();
                }
                ballPhysics.mass = massF;
            }
        }
    }
    public void ChangeGravity()
    {
        if (gravity != null)
        {
            if (gravity.text != null)
            {
                ballPhysics.gravitation = float.Parse(gravity.text);
            }
        }
    }
    public void ChangeBounciness()
    {
        if (bounciness != null)
        {
            if (bounciness.text != null)
            {
                if (float.Parse(bounciness.text) < 0)
                {
                    ballPhysics.bounciness = 0;
                    bounciness.text = "0";
                }
                else ballPhysics.bounciness = float.Parse(bounciness.text);
            }
        }
    }
    public void ChangeFriction()
    {
        if (friction != null)
        {
            if (friction.text != null)
            {
                ballPhysics.frictionCoefficient = float.Parse(friction.text);
            }
        }
    }
    public void ChangeDrag()
    {
        if (drag != null)
        {
            if (drag.text != null)
            {
                if (float.Parse(drag.text) < 0)
                {
                    ballPhysics.drag = 0;
                    drag.text = "0";
                }
                else ballPhysics.drag = float.Parse(drag.text);
            }
        }
    }
}
