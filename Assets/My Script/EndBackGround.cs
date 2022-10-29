using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBackGround : MonoBehaviour
{
    private bool time = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TimeCount", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (time && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    private void TimeCount()
    {
        time = true;
    }
}
