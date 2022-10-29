using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBackGround : MonoBehaviour
{
    public Light directionalLight;
    private bool check = false;
    

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponent<Light>();
        directionalLight.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ScoreManager.count = 0;
            check = true;
        }

        if (check)
        {
            directionalLight.intensity += 0.001f;
            if(directionalLight.intensity > 1.0f)
            {
                directionalLight.intensity = 1.0f;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
