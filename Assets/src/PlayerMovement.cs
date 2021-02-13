using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    public int forceFactor = 1;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyForce();
    }

    private void ApplyForce()
    {
        _rigidbody2d.AddForce(GetNormalizedInput() * forceFactor);
    }

    private Vector2 GetNormalizedInput()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        return input;
    }
}
