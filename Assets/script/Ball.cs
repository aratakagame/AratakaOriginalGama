using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boss")
        {
            Boss = GameObject.Find("Boss");
            Boss.SendMessage("Damage");
            Destroy(this.gameObject);
        }
    }
}
