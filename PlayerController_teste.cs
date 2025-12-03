using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float inputHorizontal;
    private float inputVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);
        rb.linearVelocity = new Vector2(inputHorizontal * speed, inputVertical * speed);

        if(inputHorizontal > 0){
            spriteRenderer.flipX = false;
        }
        else if (inputHorizontal < 0)
            spriteRenderer.flipX = true;
    }

}
