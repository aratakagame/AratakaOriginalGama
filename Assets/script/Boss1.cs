using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    float cooldown = 0f;
    int pattern = 0;
    public GameObject marutan1;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown < 0)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            pattern = Random.Range(1, 3);
            if (pattern == 1)
            {
                cooldown = 3;
                Vector3 posi = this.transform.position;
                posi = posi + new Vector3(0, 2, 0);
                GameObject Marutan1 = Instantiate(marutan1, posi, Quaternion.identity);
            }
            else
            {
                cooldown = 8;
                transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
        cooldown = cooldown - Time.deltaTime;
        if (pattern == 2)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (cooldown < 7)
            {
                if (cooldown < 1)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if(cooldown < 4)
                {
                    rb.AddForce(300.0f, 0.0f, 0.0f);
                    Debug.Log("WOW");
                }
                else
                {
                    rb.AddForce(-300.0f, 0.0f, 0.0f);
                }
            }
        }
        if(hpSlider.value < 1 && cooldown < 10)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            cooldown = 999f;
            rb.AddForce(0.0f, 40000.0f, 40000.0f);
            rb.constraints = RigidbodyConstraints.None;
            rb.angularVelocity = new Vector3(2000, 1000, 0);
            Invoke("ChangeScene", 3.0f);
        }
    }
    public void Damage()
    {
        hpSlider.value = hpSlider.value - 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player.SendMessage("Damage");
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Stage2");
    }
}
