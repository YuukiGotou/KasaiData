using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    private Status status;
    private Rigidbody2D rd;
    private GameObject scoretext;
    private ScoreManager score;
    private bool check = false;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        status = player.GetComponent<Status>();
        rd = player.GetComponent<Rigidbody2D>();
        scoretext = GameObject.Find("Score");
        score = scoretext.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(status.HP <= 0)
        {
            status.damage = true;
            rd.bodyType = RigidbodyType2D.Static;
            check = true;
        }
        if (check)
        {
            Quaternion q = Quaternion.Euler(0, 0, 10);
            player.transform.position += new Vector3(-0.1f, 0.1f, 0);
            player.transform.rotation *= q;
            time += 0.01f;
            if(time > 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
