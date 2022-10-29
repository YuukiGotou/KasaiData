using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI countText;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
        countText.text = "Score:" + count;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Score:" + count;
    }
}
