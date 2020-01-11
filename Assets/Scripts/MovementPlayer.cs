using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f; //movimiento horizontal

    public float gravity = -9.81f; //gravedad Movimiento vertical

    public float jumpHeight = 3f;  //salto 

    public int Health = 100;

    public Text healthtext;

    //groundcheck
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        healthtext.text = Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = Health.ToString();
        if (Health <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)

        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f* gravity);

        }

        //gravedad Movimiento vertical
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyArm")
        {
            Health -= 5;
        }
    }
}