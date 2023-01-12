using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Global Variables
    Rigidbody player;
    [SerializeField] float speed = 6f;
    [SerializeField] float JumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpsound;
    //Methods
    bool CheckGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    // Start is called before the first frame update
    void Start()
    {
         player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //get axis return 1 if right/up return -1 if left/down
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //*Movements*//

        //sets movement in all directions(left/right/forward/back)
        player.velocity = new Vector3(horizontalInput * speed, player.velocity.y, verticalInput * speed);

        //Jump!
        if (Input.GetButtonDown("Jump")&& CheckGround())
        {
           player.velocity = new Vector3(player.velocity.x, JumpForce, player.velocity.z);
            jumpsound.Play();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }

    }
}
