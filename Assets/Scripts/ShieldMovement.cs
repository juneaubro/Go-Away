using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    public Joystick joystick;
    /* float minX = -.8f;
    float minY = -.8f;
    float maxX = .8f;
    float maxY = .8f; */
    private float RotateSpeed = 5f;
    private float Radius = 0.8f;

    public GameObject target;
    public float speed = 5f;
    public Vector3 direction = Vector3.forward;

    private Vector2 center;
    private float angle;

    public void FixedUpdate()
    {
        Move();
    }

    //figure out translating joystick horizontal + vertical to z rotation values
    private void Move()
    {
        Vector2 movementInput = new Vector2(joystick.Horizontal,joystick.Vertical);
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;

        //angle += RotateSpeed;
        transform.position = movementInput;
        transform.position = center + offset;

        //transform.RotateAround(target.transform.position, direction, speed * Time.deltaTime);
        
    }
}
