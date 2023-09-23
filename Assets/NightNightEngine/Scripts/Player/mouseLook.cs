using System;
using UnityEngine;

namespace NightNightEngine.Player
{
    public class MouseLook : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Transform cam;

        [Header("Data")] [SerializeField] private float lookSpeed;

        /// <summary>
        /// How Quick Should the lerp actually be?
        /// </summary>
        [SerializeField] private float sharpness = 15;

        /// <summary>
        /// How Far up and Down should the player be able to look?
        /// </summary>
        [SerializeField] private Vector2 xClamp;

        /// <summary>
        /// holds the rotation values
        /// </summary>
        private Vector2 _rot;

        /// <summary>
        /// holds the input values
        /// </summary>
        private Vector2 _input;

        private void Start()
        {
            _rot = new Vector2(cam.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y);
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.instance.gamePaused)
            {
                UpdateInput();
                DoRot();
            }
        }

        /// <summary>
        /// Update our Data for input pulling X and Y from the mouse Delta
        /// </summary>
        void UpdateInput()
        {
            _input = NightUtils.SmootherLerp(_input,
                new Vector2(Input.GetAxis("Mouse X"),
                    Input.GetAxis("Mouse Y")), sharpness);
        }

        /// <summary>
        /// Do the actual rotation
        /// </summary>
        void DoRot()
        {
            _rot += new Vector2(_input.y * Time.deltaTime * lookSpeed, _input.x * Time.deltaTime * lookSpeed);
            _rot.x = Mathf.Clamp(_rot.x, xClamp.x, xClamp.y);
            cam.localRotation = Quaternion.identity;

            // Apply the new rotations
            transform.rotation = Quaternion.Euler(0, _rot.y, 0);
            cam.Rotate(Vector3.right, _rot.x);
        }
    }
}
