using UnityEngine;

namespace Nirville
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] int playerNumber = 1;
        [SerializeField] float moveSpeed = 2;
        [SerializeField] float turnSpeed = 4;

        Rigidbody playerRigibody;

        float horizontalInput;
        float verticalInput;

        string horizontalAxisName;
        string verticalAxisName;

        void Awake()
        {
            playerRigibody = GetComponent<Rigidbody>();
        }

        void OnEnable()
        {
            horizontalInput = 0;
            verticalInput = 0;
        }

        void Start()
        {
            horizontalAxisName = "Horizontal" + playerNumber;
            verticalAxisName = "Vertical" + playerNumber;
        }

        void Update()
        {
            horizontalInput = Input.GetAxis(horizontalAxisName);
            verticalInput = Input.GetAxis(verticalAxisName);
        }

        void FixedUpdate()
        {
            Move();
            Turn();
        }

        private void Move()
        {
            Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
            playerRigibody.MovePosition(playerRigibody.position + movement);
        }

        private void Turn()
        {
            float turn = horizontalInput * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            playerRigibody.MoveRotation(playerRigibody.rotation * turnRotation);
        }
    }

}
