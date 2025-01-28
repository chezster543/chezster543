using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Variables
    // only for GameObjects with a character controller applied
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
    }
    // Access Unity APIs for components
    public CharacterController controller;
    public Animator anim;

    // Assign an audio clip file and access the AudioSource API
    public AudioClip runningSound;
    private AudioSource audioSource;

    // Values for rotation, jump height, and running speeds
    public float runningSpeed = 4.0f;
    public float rotationSpeed = 100.0f;
    public float jumpHeight = 6.0f;

    // Declare player input variables
    private float jumpInput;
    private float runInput;
    private float rotateInput;

    // Declare a 3D vector for moving
    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
        {
            runInput = Input.GetAxis("Vertical");
            rotateInput = Input.GetAxis("Horizontal");
            
    // If no Rigidbody or is Kinematic, do nothing
    if (body == null || body.isKinematic)
    {
        return;
    }
    // Calculate push direction from move direction, only along x and z axes - no vertical or y-axis pushing
    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    // Apply the push power and pushing direction to the pushed object's velocity
    if (hit.gameObject.tag == "Object")
    {
        body.velocity = pushDir * pushPower;
    }

    // Don't push ground or platform GameObjects below character
    if (hit.moveDirection.y < -0.3)
    {
        return;
    }
    // Calculate push direction from move direction, only along x and z axes - no vertical or y-axis pushing
    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    // Apply the push power and pushing direction to the pushed object's velocity
    if (hit.gameObject.tag == "Object")
    {
        body.velocity = pushDir * pushPower;
    }
        }
    }
}