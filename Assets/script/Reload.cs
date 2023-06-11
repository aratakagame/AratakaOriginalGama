using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reload : MonoBehaviour
{
    float count = 0.1f;
    [SerializeField]
    private TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        count = count - Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && int.Parse(Text.text) != 0)
        {
            count = 0.03f;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (count < 0 && Text.text != "3")
        {
            Text.text = "3";
        }
    }
}
