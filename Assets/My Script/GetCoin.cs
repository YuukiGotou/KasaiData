using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public int HealthUP = 10;
    public int AttackUP = 1;
    public int DefendUP = 1;
    public AudioClip getcoin;
    private AudioSource callsound;
    private GameObject player;
    private Status status;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        status = player.GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            status.HP += HealthUP;
            StatusManager.hp += HealthUP;
            status.ATK += AttackUP;
            StatusManager.atk += AttackUP;
            status.DEF += DefendUP;
            StatusManager.def += DefendUP;
            Destroy(gameObject);
        }
    }
}
