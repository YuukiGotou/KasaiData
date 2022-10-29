using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject SpritePrefab1;
    [SerializeField] private GameObject SpritePrefab2;
    private float time;
    private float statusup;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        count = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        statusup += Time.deltaTime / 5;
        if (time > count)
        {
            if (count < 1.0f)
            {
                count = 1.0f;
            }
            else
            {
                count *= 0.90f;
            }
            time = 0;

            if(Random.value > 0.5f)
            {
                var obj1 = Instantiate(SpritePrefab1);
                obj1.transform.localPosition = new Vector2(Random.Range(-8.0f, 8.0f), 5.0f);
                var status = obj1.GetComponent<Status>();
                status.HP += (int)statusup;
                status.ATK += (int)statusup;
                status.DEF += (int)(statusup / 2);
            }
            else
            {
                var obj2 = Instantiate(SpritePrefab2);
                obj2.transform.localPosition = new Vector2(Random.Range(-8.0f, 8.0f), 5.0f);
                var status = obj2.GetComponent<Status>();
                status.HP += (int)(statusup * 2);
                status.ATK += (int)statusup;
                status.DEF += (int)(statusup / 2);

            }

        }
    }
}
