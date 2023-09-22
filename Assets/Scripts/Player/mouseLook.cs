using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public Transform camera;

    public float lookSpeed;

    public Vector2 xClamp;

    public Vector2 rot;

    public Vector2 input;

    public float sharpness = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();
        doRot();
    }

    void updateInput()
    {
        input = nightUtils.smootherLerp(input,
            new Vector2(Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")), sharpness);
    }

    void doRot()
    {
        rot += new Vector2(input.y * Time.deltaTime * lookSpeed, input.x * Time.deltaTime * lookSpeed);
        rot.x = Mathf.Clamp(rot.x, xClamp.x, xClamp.y);
        camera.localRotation = Quaternion.identity;

        // Apply the new rotations
        transform.rotation = Quaternion.Euler(0, rot.y, 0);
        camera.Rotate(Vector3.right, rot.x);
    }
}
