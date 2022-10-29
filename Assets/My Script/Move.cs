using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb; // �d�͐ݒ�
    private Animator animator; // �v���C���[�̃A�j���[�V����
    private Status status; // �v���C���[�̃X�e�[�^�X
    private AudioSource audio;
    public AudioClip Audio_Jump;
    public AudioClip Audio_Damage;
    public LayerMask CollisionLayer; // �n�ʔ���̎���
    public LayerMask DamageLayer; // ����(�_���[�W)����̎���

    private float x_val; // ���E�����̌���
    private float speed; // �ړ����x
    public float inputSpeed = 3; // �ݒ�X�s�[�h
    public float jumpPower = 300; // �ݒ�W�����v��

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
        // ���E�̕������� (�� : -1, �E : +1, �ړ����Ȃ� : 0)
        x_val = Input.GetAxis("Horizontal");

        // �����̍��W�ʒu�̎擾
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;

        // ���̏ꏊ�܂ŗ������ꍇ�̓_���[�W���󂯂ď����n�_�ɖ߂�
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
            // �_���[�W���󂯂Ă���Œ��͍d��������
            if (jumpFig && (rb.velocity.y == 0))
            {
                status.damage = false;
            }
            // ���ݒn���n�ʂłȂ����ǂ����̊m�F
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
