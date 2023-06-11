using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject brick;
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
        if (other.gameObject.name == "Ball(Clone)")
        {
            int i = 0;

            while (i < 10)
            {
                Vector3 posi = this.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -2);
                GameObject NewBall = Instantiate(brick, posi, Quaternion.identity);
                Vector3 force = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                NewBall.GetComponent<Rigidbody>().velocity = force * 5;
                i++;
            }
            Destroy(this.gameObject);
        }
    }
}
