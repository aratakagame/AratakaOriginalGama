using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyrami : MonoBehaviour
{
    int dead = 0;
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
        if (Vector3.Distance(this.transform.position, player.transform.position) > 20 && dead == 0)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            Vector3 vector3 = player.transform.position - this.transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            this.transform.rotation = quaternion;
            Vector3 target = player.transform.position;
            Vector3 posi = this.transform.position;
            Vector3 force = (target - posi).normalized;
            rb.AddForce(force * 35, ForceMode.Force);
        }
        if (dead == 1)
        {
            rb.AddForce(0.0f, 1000.0f, 1000.0f);
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
