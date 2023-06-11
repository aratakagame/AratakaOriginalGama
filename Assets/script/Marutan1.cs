using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marutan1 : MonoBehaviour
{
    GameObject player;
    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = cooldown + Time.deltaTime;
        if(cooldown > 0)
        {
            if(Random.Range(1, 3) == 1)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(-15.0f, 0.0f, 0.0f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Playe0r")
        {
            GameObject Player = GameObject.Find("Player");
            Player.SendMessage("Damage");
        }
    }
}

