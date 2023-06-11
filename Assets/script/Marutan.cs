using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marutan : MonoBehaviour
{
    int dead = 0;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Vector3.Distance(this.transform.position, player.transform.position) > 10 && dead == 0)
        {
            rb.velocity = Vector3.zero;
        }
        if (dead == 1)
        {
            rb.AddForce(0.0f, 1000.0f, 100.0f);
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
