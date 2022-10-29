using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Move : MonoBehaviour
{
    public LayerMask CollisionLayer;
    private float scale;
    private Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;
        if (Physics2D.Linecast(left_SP, EP, CollisionLayer) || Physics2D.Linecast(right_SP, EP, CollisionLayer))
        {
            // ë´èÍÇÃí[Ç…Ç¢ÇÈÇ©Ç«Ç§Ç©ÇÃîªíË
            if (!(Physics2D.Linecast(left_SP, EP,CollisionLayer) && Physics2D.Linecast(right_SP, EP, CollisionLayer)))
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
}