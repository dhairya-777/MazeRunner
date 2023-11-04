using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character variables
    private CharacterController charControl;
    public float speed = 6.0f;

    // Camera rotation variables
    public Transform cameraLocation;
    private float mouseSensitivity = 2.0f;
  //  public AudioClip walkSound;
    public AudioSource walkSound;

    // for position change

    //over


    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();

        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(walkSound);
        

        //for position change

        //over
    }

  
    void Update()
    {
        Move();
       
        Rotate();

        if ( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walkSound.enabled = true;
        }
        else
        {
            walkSound.enabled = false;
        }


    }
    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vert + transform.right * horiz;
        charControl.Move(speed * Time.deltaTime * move);
        
        

    }

    private void Rotate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        transform.Rotate(0, horiz * mouseSensitivity, 0);
        cameraLocation.LookAt(transform);

    }
}
