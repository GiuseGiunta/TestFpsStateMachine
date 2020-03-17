using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermoving : MonoBehaviour
{
    public static Playermoving PSing;
    Animator PSM;

    public Camera cam;
    public Transform Stand;
    public Transform Knee;

    public CharacterController controller;

    //public Transform groundCheck;
  // public float groundDistance = 0.5f;
   // public LayerMask groundMansk;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 5f;

    public Vector3 velocity;

    
    // bool isGrounded;

    private void Awake()
    {
        if (PSing == null)
        {
            PSing = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        PSing.PSM = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMansk);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift)) { speed = 30f; } else { speed = 12f; }

        controller.Move(move * speed * Time.deltaTime);

        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {

            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }


    }



    public delegate void PlayerSM();

    public static PlayerSM GTG;

    public static PlayerSM GTJ;

    public static PlayerSM GTR;

    public static PlayerSM GTK;

    void GoToG()
    {
        if (!PSing.PSM.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            PSing.PSM.SetTrigger("GTG");
        }
    }

    void GoToJ()
    {
        if (!PSing.PSM.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
        {
            PSing.PSM.SetTrigger("GTJ");
        }
    }

    void GoToR()
    {
        if (!PSing.PSM.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            PSing.PSM.SetTrigger("GTR");
        }
    }
    void GoToK()
    {
        if (!PSing.PSM.GetCurrentAnimatorStateInfo(0).IsName("Kneeling"))
        {
            PSing.PSM.SetTrigger("GTK");
        }
    }

    //void PSetUp()
    //{
    //    GTG += PSing.GoToG;
    //    GTJ += PSing.GoToJ;
    //    GTR += PSing.GoToR;
    //    GTK += PSing.GoToK;
    //}

    //public void OnEnable()
    //{
    //    PSetUp();
    //}

    //public void OnDisable()
    //{
    //    GTG -= PSing.GoToG;
    //    GTJ -= PSing.GoToJ;
    //    GTR -= PSing.GoToR;
    //    GTK -= PSing.GoToK;
    //}
}
