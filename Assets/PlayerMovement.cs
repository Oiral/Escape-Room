using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //Vector3 targetPos;

    public float moveSpeed = 5;
    public float gravity = 9f;

    //[Tooltip("Layers that will stop movement of the player")]
    //public string[] maskLayers;

    CharacterController controller;

    private void Start()
    {
        //targetPos = transform.position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKeyDown(KeyCode.W)) Move(Vector3.forward);
        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKeyDown(KeyCode.S)) Move(Vector3.back);
        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A)) Move(Vector3.left);
        if (Input.GetKey(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.D)) Move(Vector3.right);
        */

        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        controller.Move(moveVector * moveSpeed * Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        controller.Move(Vector3.up * gravity * Time.deltaTime);
    }

    void Move(Vector3 dir)
    {
        GetComponent<CharacterController>().Move(dir * moveSpeed * Time.deltaTime);

        /*
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(targetPos, dir, out hit, 1f,LayerMask.GetMask(maskLayers)) == false)
        {
            targetPos += dir;
        }
        else
        {
            Debug.DrawRay(targetPos, dir * hit.distance, Color.yellow, 2f);
        }*/
    }
}
