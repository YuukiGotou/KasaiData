using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject SpritePrefab1;
    [SerializeField] private GameObject SpritePrefab2;
    [SerializeField] private GameObject SpritePrefab3;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 10.0f)
        {
            time = 0;
            var obj1 = Instantiate(SpritePrefab1);
            var obj2 = Instantiate(SpritePrefab2);
            var obj3 = Instantiate(SpritePrefab3);
            obj1.transform.localPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-2.0f, 0.0f));
            obj2.transform.localPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-2.0f, 0.0f));
            obj3.transform.localPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-2.0f, 0.0f));
        }
    }
}
