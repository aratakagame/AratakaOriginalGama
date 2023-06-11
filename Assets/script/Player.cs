using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioClip Attack;
    public AudioClip Attack2;
    AudioSource audioSource;
    int count = 5;
    float damage = 0.0f;
    float power = 1.0f;
    [SerializeField]
    private TextMeshProUGUI Text;
    private Vector3 mouse;
    private Vector3 posi;
    private Vector3 target;
    public GameObject Ball;
    [SerializeField] private Vector3 Force;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Sand")
        {
            power = 0.3f;
            Debug.Log("1");
        }
    }

    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody‚ðŽæ“¾
        if (Input.GetMouseButtonDown(0) && int.Parse(Text.text) != 0 && damage < 3)
        {
            audioSource.PlayOneShot(Attack);
            count = int.Parse(Text.text) - 1;
            Text.text = "" + count;
            mouse = Input.mousePosition;
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0));
            Vector3 posi = this.transform.position;
            target.z = 0;
            posi.z = 0;
            Vector3 force = (target - posi).normalized;  // —Í‚ðÝ’è
            Force = new Vector3(Force.x, Force.y, 0);
            GameObject NewBall = Instantiate(Ball, posi, Quaternion.identity);
            NewBall.GetComponent<Rigidbody>().velocity = force * 30;
            Destroy(NewBall, 0.4f);

            force.x = -1 * force.x;
            force.y = -1 * force.y;

            rb.AddForce(force * 10 * power, ForceMode.Impulse);
        }else if(Input.GetMouseButtonDown(0) && int.Parse(Text.text) == 0 && damage < 3)
        {
            audioSource.PlayOneShot(Attack2);
        }

        damage = damage - Time.deltaTime;
        if(damage > 3)
        {
            transform.Rotate(new Vector3(0, 0, 10));
        }
        power = 1.0f;
        var scene = SceneManager.GetActiveScene();
        if (this.transform.position.x > 230 && this.transform.position.x < 430 && scene.name == "Stage2")
        {
            rb.AddForce(-5, 0, 0, ForceMode.Force);
        }
    }

    public void Damage()
    {
        if(damage < 0)
        {
            GameObject time = GameObject.Find("Time");
            Rigidbody rb = GetComponent<Rigidbody>();
            damage = 5.0f;
            rb.AddForce(0.0f, 1000.0f, 0.0f);
            time.SendMessage("Damage");
        }
    }
}
