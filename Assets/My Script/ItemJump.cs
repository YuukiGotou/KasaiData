using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask CollisionLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.2f;
        if (IsCollision(CollisionLayer, left_SP, right_SP, EP))
        {
            rb.velocity = new Vector2(-1.0f, 7.5f);
        }

        bool IsCollision(LayerMask layer, Vector3 left_SP, Vector3 right_SP, Vector3 EP)
        {
            return Physics2D.Linecast(left_SP, EP, layer) || Physics2D.Linecast(right_SP, EP, layer);
        }
    }
}
