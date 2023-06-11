using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void OnCrick()
    {
        Invoke("ChangeScene", 0.0f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Stage1");
    }

}