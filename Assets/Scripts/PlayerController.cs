using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    float walkSpeed = 6.0f;
    float runSpeed = 10.0f;
    float jumpSpeed = 8.0f;
    float gravity = 20.0f;

    public Camera cam;
    float mouseHorizontal = 3.0f;
    float mouseVertical = 2.0f;
    public Canvas canvasWin;


    float minRotation = -65.0f;
    float maxRotation = 60.0f;
    float horimouse, vertimouse;

    public GameObject player;

    Rigidbody rb;

    private Vector3 move = Vector3.zero;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        canvasWin.gameObject.SetActive(false);
    }
    void Update()
    {
        horimouse = mouseHorizontal * Input.GetAxis("Mouse X");
        vertimouse += mouseVertical * Input.GetAxis("Mouse Y");

        vertimouse = Mathf.Clamp(vertimouse, minRotation, maxRotation);


        cam.transform.localEulerAngles = new Vector3(-vertimouse, 0, 0);

        transform.Rotate(0, horimouse, 0);


        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
                move = transform.TransformDirection(move) * runSpeed;
            else
                move = transform.TransformDirection(move) * walkSpeed;

            if (Input.GetKey(KeyCode.Space))

                move.y = jumpSpeed;
        }
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Collision Detected");
            canvasWin.gameObject.SetActive(true);
        }
    }
}
