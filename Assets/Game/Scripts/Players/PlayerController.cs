using System;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject normalTear;
    [SerializeField] private Transform tearsSlot;
    [SerializeField] public float shootForce = 10f;
    [SerializeField] private float shootRate = 0.2f;

    [Header("Pool Settings")]
    [SerializeField] private int poolSize = 1;
    [SerializeField] private float tearLifetime = 3f;
    [SerializeField] private bool canExpand = true;
    [SerializeField] private int maxPoolSize = 100;

    private bool isShooting;
    private float lastShootTime = 0f;
    private Rigidbody rb;
    private Vector2 moveInput;

    private PoolManager pm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pm = GameManager.Get.poolManager;
        pm.InitializeTearPool(normalTear, tearsSlot, poolSize);
    }

    private void Update()
    {
        if (isShooting && Time.time > lastShootTime + shootRate)
        {
            PlayerShoot();
            lastShootTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Player Move
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    // Player Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) // Just pressed
        {
            // Simple jump - you might want to add ground check
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    // Player Take Damage
    public void OnTakeDamage(InputAction.CallbackContext context)
    {
        if (context.performed) // Just pressed
        {
            float playerHP = GameManager.Get.playerCharacter.GetPlayerHealth();
            GameManager.Get.playerCharacter.SetPlayerHealth(playerHP - 1);
        }
    }

    // Player shoot
    public void OnPlayerShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShooting = true;
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }

    public void PlayerShoot()
    {
        GameObject tear = pm.GetInactiveTear(normalTear, tearsSlot, canExpand, maxPoolSize);

        if (tear != null)
        {
            // Position and Active
            tear.transform.position = transform.position;
            tear.SetActive(true);

            // Get Position
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.y = transform.position.y;
            Vector3 direction = (worldMousePosition - transform.position).normalized;

            // Shoot
            Rigidbody tearRb = tear.GetComponent<Rigidbody>();
            if (tearRb != null)
            {
                tearRb.linearVelocity = Vector3.zero;
                tearRb.AddForce(direction * shootForce, ForceMode.Impulse);
            }


            pm.UseCouroutine(tear, tearLifetime);
        }
    }
}
