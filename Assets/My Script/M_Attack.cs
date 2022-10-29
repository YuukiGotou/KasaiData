using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class M_Attack : MonoBehaviour
{
    private GameObject player;
    private GameObject score;
    private Rigidbody2D rb;
    private Status M_st; // モンスターのステータス
    private Status P_st; // プレイヤーのステータス
    private AudioSource audio;
    public AudioClip Audio_Attack;
    public AudioClip Audio_Damage;
    public AudioClip Audio_Break;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        score = GameObject.Find("Score");
        rb = player.GetComponent<Rigidbody2D>();
        M_st = GetComponent<Status>(); // 敵のステータス
        P_st = player.GetComponent<Status>(); // プレイヤーのステータス
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーとの衝突
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーの方が高い位置にいる場合（踏んづけた場合）
            if (collision.transform.position.y > transform.position.y)
            {
                // プレイヤーが上に跳ねる処理
                rb.AddForce(new Vector2(0, 5.0f), ForceMode2D.Impulse);

                // 敵のダメージ処理
                if (P_st.ATK > M_st.DEF)
                {
                    M_st.HP -= P_st.ATK - M_st.DEF;
                    if (M_st.HP <= 0)
                    {
                        ScoreManager.count += M_st.ATK * M_st.DEF;
                        Destroy(gameObject);
                    }
                    else
                    {
                        audio.PlayOneShot(Audio_Attack);
                    }
                }
            }
            else
            {
                // プレイヤーのダメージ処理
                if (M_st.ATK > P_st.DEF) {
                    P_st.HP -= M_st.ATK - M_st.DEF;
                    StatusManager.hp -= M_st.ATK - M_st.DEF;
                    audio.PlayOneShot(Audio_Damage);
                    if (P_st.HP > 0)
                    {
                        // プレイヤーが吹き飛ぶ処理
                        if (collision.transform.position.x > transform.position.x)
                        {
                            rb.AddForce(new Vector2(4.0f, 4.0f), ForceMode2D.Impulse);
                        }
                        else
                        {
                            rb.AddForce(new Vector2(-4.0f, 4.0f), ForceMode2D.Impulse);
                        }
                        P_st.damage = true;
                    }
                }
            }
        }
    }
}