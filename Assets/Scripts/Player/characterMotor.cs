using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMotor : MonoBehaviour
{
    public CharacterController controller;
    public float sharpness;
    public Vector2 input;
    public float moveSpeed;
    public Vector3 forward;
    public Vector3 right;

    public bool useGravity;

    public Vector3 gravity = new Vector3(0, -9.8f, 0);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();
        updateNormals();
        move();
    }

    void updateInput()
    {
        input = nightUtils.smootherLerp(input,
            new Vector2(Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")), sharpness);
    }

    void updateNormals()
    {
        forward = transform.forward;
        right = transform.right;
    }

    void move()
    {
        Vector3 v = forward * input.y * Time.deltaTime * moveSpeed;
        Vector3 h = right * input.x * Time.deltaTime * moveSpeed;
        Vector3 velocity = v + h;
        if (useGravity)
        {
            velocity += gravity * Time.deltaTime;
        }

        controller.Move(velocity);
    }
}
