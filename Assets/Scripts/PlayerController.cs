using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!! Do przepisania lub wykombinowania jak to dopasowaæ do obracania postaci - https://www.youtube.com/watch?v=YV5KOZHsIz4 !!!
public class Pla : MonoBehaviour
{
    private Player playerInput;
    private Rigidbody2D controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    private float gravityValue = 0f;

    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        controller.velocity = new Vector2(Input.GetAxisRaw("Horizontal") , 0f);
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x , movementInput.y , 0f);
        controller.Move(move * Time.deltaTime * playerSpeed)

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
