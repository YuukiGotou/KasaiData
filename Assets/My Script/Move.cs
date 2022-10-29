using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb; // 重力設定
    private Animator animator; // プレイヤーのアニメーション
    private Status status; // プレイヤーのステータス
    private AudioSource audio;
    public AudioClip Audio_Jump;
    public AudioClip Audio_Damage;
    public LayerMask CollisionLayer; // 地面判定の識別
    public LayerMask DamageLayer; // 落下(ダメージ)判定の識別

    private float x_val; // 左右方向の決定
    private float speed; // 移動速度
    public float inputSpeed = 3; // 設定スピード
    public float jumpPower = 300; // 設定ジャンプ力

    private bool jumpFig = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<Status>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左右の方向決定 (左 : -1, 右 : +1, 移動しない : 0)
        x_val = Input.GetAxis("Horizontal");

        // 足元の座標位置の取得
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;

        // 一定の場所まで落ちた場合はダメージを受けて初期地点に戻る
        if (IsCollision(DamageLayer, left_SP, right_SP, EP))
        {
            status.HP -= 1;
            StatusManager.hp -= 1;
            audio.PlayOneShot(Audio_Damage);
            status.damage = true;
            transform.position = new Vector3(-10,0,0);
        }
        else 
        {
            jumpFig = IsCollision(CollisionLayer, left_SP, right_SP, EP);
            // ダメージを受けている最中は硬直させる
            if (jumpFig && (rb.velocity.y == 0))
            {
                status.damage = false;
            }
            // 現在地が地面でないかどうかの確認
            if (Input.GetKeyDown("space") && jumpFig)
            {
                animator.SetTrigger("Jump");
                rb.AddForce(Vector2.up * jumpPower);
                audio.PlayOneShot(Audio_Jump);
            }
        }
    }

    void FixedUpdate()
    {
        if (!status.damage)
        {
            if (x_val == 0)
            {
                speed = 0;
                animator.SetTrigger("Stop");
            }
            else if (x_val > 0)
            {
                speed = inputSpeed;
                animator.SetTrigger("Horizontal");
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x_val < 0)
            {
                speed = inputSpeed * -1;
                animator.SetTrigger("Horizontal");
                transform.localScale = new Vector3(-1, 1, 1);
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    bool IsCollision(LayerMask layer, Vector3 left_SP, Vector3 right_SP, Vector3 EP)
    {
        return Physics2D.Linecast(left_SP, EP, layer) || Physics2D.Linecast(right_SP, EP, layer);
    }
}
