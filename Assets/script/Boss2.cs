using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    float cooldown = 0f;
    int pattern = 0;
    public Slider hpSlider;
    public GameObject player;
    public GameObject up;
    Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (cooldown < 0)
        {
            if(hpSlider.value > 50)
            {
                pattern = 1;
            }
            else
            {
                pattern = 2;
            }
            rb.velocity = Vector3.zero;
            if (pattern == 1)
            {
                cooldown = 3.5f;
            }
            if (pattern == 2)
            {
                cooldown = 6000.0f;
                transform.position = new Vector3(5, -3.1f, 0);
                transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            }
        }
        if(pattern == 1)
        {
            Vector3 vector3 = player.transform.position - this.transform.position;
            if (cooldown < 3.0f)
            {
                rb.AddForce(force * 360, ForceMode.Force);
            }
            else
            {
                Quaternion quaternion = Quaternion.LookRotation(vector3);
                this.transform.rotation = quaternion;
                Vector3 target = player.transform.position;
                Vector3 posi = this.transform.position;
                force = (target - posi).normalized;
            }
        }
        if (pattern == 2 && cooldown < 10000)
        {
            up.transform.localPosition = new Vector3(0, 0, Mathf.Sin(cooldown * 1.5f) * 10 + 10);
            transform.localPosition = new Vector3(Mathf.Sin(cooldown - 600 / 4) * 5.5f, -3, 0);
        }
        if (hpSlider.value < 1 && cooldown < 10000)
        {
            cooldown = 99999f;
            rb.AddForce(0.0f, 40000.0f, 40000.0f);
            rb.constraints = RigidbodyConstraints.None;
            rb.angularVelocity = new Vector3(2000, 1000, 0);
            Invoke("ChangeScene", 3.0f);
        }
        cooldown = cooldown - Time.deltaTime;
    }
    public void Damage()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        hpSlider.value = hpSlider.value - 1;
        rb.AddForce(force * -720, ForceMode.Force);
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
        SceneManager.LoadScene("Stage3");
    }
}
