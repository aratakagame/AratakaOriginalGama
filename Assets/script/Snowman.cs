using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    int dead = 0;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Ball;
    float cooldown = 0f;
    public float houkou = -1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Vector3.Distance(this.transform.position, player.transform.position) > 10 && dead == 0)
        {
            rb.velocity = Vector3.zero;
        }
        else
        { 
            if(cooldown < 0)
            {
                Vector3 posi = this.transform.position + new Vector3(-0.8f, 1, 0);
                Vector3 force = new Vector3((houkou * 0.2f), 0.1f, 0);
                GameObject NewBall = Instantiate(Ball, posi, Quaternion.identity);
                NewBall.GetComponent<Rigidbody>().velocity = force * 30;
                Destroy(NewBall, 5.0f);
                cooldown = 2f;
            }
            cooldown = cooldown - Time.deltaTime;
        }
        if (dead == 1)
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball(Clone)" && dead == 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            cooldown = 999f;
            rb.AddForce(0.0f, 1000.0f, 1000.0f);
            rb.constraints = RigidbodyConstraints.None;
            rb.angularVelocity = new Vector3(50, 25, 0);
            dead = 1;
            GameObject time = GameObject.Find("Time");
            time.SendMessage("Kill");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player.SendMessage("Damage");
        }
    }
}
