using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public static float time = 0f;
    [SerializeField]
    private TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage()
    {
        time -= 200;
    }
    public void Kill()
    {
        time += 100;
    }
    public void Gold()
    {
        time += 1000;
    }
    public void Silver()
    {
        time += 10;
    }
}
