using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _controller;

    public float _speed = 6f;

    public float _rotationSpeed = 60;

    Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);

        // if(direction.magnitude >= 0.1f)
        // {
        //     float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //     transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


        //     controller.Move(transform.forward * speed * Time.deltaTime);
        // }
    }
}
