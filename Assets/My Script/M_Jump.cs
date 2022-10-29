using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Jump : MonoBehaviour
{
    public LayerMask CollisionLayer;
    private float scale;
    private Vector3 v;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position + Vector3.up * 0.1f;
        Vector3 EP2 = transform.position - Vector3.up * 0.1f;
        if (Physics2D.Linecast(left_SP, EP2, CollisionLayer) || Physics2D.Linecast(right_SP, EP2, CollisionLayer))
        {
            rb.velocity = new Vector2(0, Random.Range(4.0f, 7.0f));
        }
        // ë´èÍÇÃí[Ç…Ç¢ÇÈÇ©Ç«Ç§Ç©ÇÃîªíË
        if (Physics2D.Linecast(left_SP, EP,CollisionLayer) || Physics2D.Linecast(right_SP, EP, CollisionLayer))
        {
            scale *= -1;
            transform.localScale = new Vector3(scale, 1, 1); // å¸Ç´ÇÃîΩì]
            transform.position -= transform.right * 0.003f * scale;
        }
        else
        {
            transform.position -= transform.right * 0.003f * scale;
        }
    }
}