using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float horizontalDirection;
    private float verticalDirection;
    public float moveSpeed = 7f;
    public float maxMoveSpeed = 7f;
    public float airLinearDrag = 2.5f;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = GetInput().x;
        verticalDirection = GetInput().y;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        ApplyAirLinearDrag();
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }


    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, verticalDirection) * moveSpeed);
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);

        if (Mathf.Abs(rb.velocity.y) > maxMoveSpeed)
            rb.velocity = new Vector2(rb.velocity.x * maxMoveSpeed, Mathf.Sign(rb.velocity.y) * maxMoveSpeed);
    }

    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }
}
