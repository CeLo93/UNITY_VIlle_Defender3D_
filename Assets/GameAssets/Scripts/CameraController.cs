using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 25.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity = 5;

    [SerializeField] float minFov = 15f;
    [SerializeField] float maxFov = 60f;
    [SerializeField] float sensitivityM = 10f;



    void Update()
    {

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivityM;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;






        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller)

        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (Input.GetKey(KeyCode.Mouse1))
        {

            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);

        }
        /* if (Input.GetKey(KeyCode.Mouse2))
        {
            //Code for action on mouse moving right
            //transform.eulerAngles += new Vector3(looker, 0, 0);
        } */

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
