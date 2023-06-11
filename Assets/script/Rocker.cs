using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocker : MonoBehaviour
{
    int dead = 0;
    public int Vero;
    GameObject player;

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
            rb.velocity = new Vector3(Vero, -1, 0);
        }
        if (dead == 1)
        {
            rb.velocity = new Vector3(0, 10, 10);
            transform.Rotate(new Vector3(5, 0, -3));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball(Clone)" && dead == 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            dead = 1;
            rb.AddForce(-10.0f, 300.0f, -50.0f);
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
