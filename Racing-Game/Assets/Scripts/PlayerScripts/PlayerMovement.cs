using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Components/Gameobjects
    public CharacterController _controller;
    public GameObject _finishLine;

    //Public Variables
    public float _speed = 6f;

    public float _rotationSpeed = 60;

    //Private Variables
    Vector3 _rotation;

    private void Start() 
    {
    }
    // Update is called once per frame
    void Update()
    {
        FinishLine finishLineScript = _finishLine.GetComponent<FinishLine>();

        //Checking the see if the player has won
        if (finishLineScript._hasWon == false)
        {
            //Moving the player
            Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
            _controller.Move(move * _speed);

            //Rotating the character
            this._rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
            this.transform.Rotate(this._rotation);
        }else return;

    }
}
