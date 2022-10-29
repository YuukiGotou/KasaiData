using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour
{
    TextMeshProUGUI StatusText;
    private GameObject player;
    public static int hp;
    public static int atk;
    public static int def;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        atk = 5;
        def = 3;
        StatusText = GetComponent<TextMeshProUGUI>();
        StatusText.text = "HP:" + hp + " ATK:" + atk + " DEF:" + def;
    }

    // Update is called once per frame
    void Update()
    {
        StatusText.text = "HP:" + hp + " ATK:" + atk + " DEF:" + def;
    }
}
