using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;
    public float crouchTimer;

    #region playerHealth
    [SerializeField] private int playerHealth = 20;
    private int currentPlayerHealth;
    #endregion

    [SerializeField] UIManager manager;

    private void Awake()
    {
        currentPlayerHealth = playerHealth;
        manager.SetMaxHealth(playerHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Bullet.damage += TakeDamage;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }
    }
    public void ProcessMover(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {

        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch ()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }



    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }

    private void TakeDamage(int damage)
    {
        if (currentPlayerHealth > 0)
        {
            currentPlayerHealth -= damage;
            manager.DamagedHealthBar(currentPlayerHealth);

            if (currentPlayerHealth <= 0)
            {
                Invoke(nameof(Die), 0.5f);
            }
        }
    }

    private void Die()
    {
        manager.ShowLostLevelMessage();
    }
}
