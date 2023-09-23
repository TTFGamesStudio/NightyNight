using UnityEngine;

namespace NightNightEngine.Player
{
    public class characterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private float sharpness;
        [SerializeField] private Vector2 input;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector3 forward;
        [SerializeField] private Vector3 right;

        [SerializeField] private bool useGravity;

        [SerializeField] private Vector3 gravity = new Vector3(0, -9.8f, 0);

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.instance.gamePaused)
            {
                UpdateInput();
                UpdateNormals();
                Move();
            }
        }

        void UpdateInput()
        {
            input = NightUtils.SmootherLerp(input,
                new Vector2(Input.GetAxis("Horizontal"),
                    Input.GetAxis("Vertical")), sharpness);
        }

        void UpdateNormals()
        {
            forward = transform.forward;
            right = transform.right;
        }

        void Move()
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
}
