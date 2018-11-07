using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 10;
    public float _rotationSpeed = 180;

    public float _gravity = 9.81f;
    public float _jumpSpeed = 3;

    private Vector3 rotation;
    private float vSpeed = 0;
    private bool canJump = true;

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);

        if (_controller.isGrounded)
        {
            // SE ESTÁ NO CHÃO, ZERA A VERTICALIDADE
            vSpeed = 0;

            // DETECTOU PULO
            if (Input.GetButton("Jump") && this.canJump)
            {
                vSpeed = _jumpSpeed;
                this.canJump = false;
            }
        }

        // SOLTOU O BOTÃO DE PULO
        if (Input.GetButtonUp("Jump"))
        {
            this.canJump = true;
        }

        vSpeed -= _gravity * Time.deltaTime;

        Vector3 move = new Vector3(0, vSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);

        this.checkForOOB();
    }

    private void checkForOOB()
    {
        if(_controller.transform.position.y < -10)
        {
            this.spawn();
        }
    }

    private void spawn()
    {
        _controller.transform.position = new Vector3(0, 5, 0);
    }
}
