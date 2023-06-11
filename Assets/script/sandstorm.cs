using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandstorm : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    [SerializeField] private Renderer a;
    // Start is called before the first frame update
    void Start()
    {
        a.enabled = false;
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 230)
        {
            a.enabled = true;
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
        }
    }
}
