using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Needle : MonoBehaviour
{
    float time = 0f;
    public GameObject needle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = this.gameObject;
        if(time % 2 < 1)
        {
            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, 1.0f, this.transform.localPosition.z);
        }
        else
        {
            obj.transform.localPosition = new Vector3(this.transform.localPosition.x, 0.35f, this.transform.localPosition.z);
        }
        time = time + Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        var scene = SceneManager.GetActiveScene();
        if (collision.gameObject.name == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player.SendMessage("Damage");
        }
    }
}
