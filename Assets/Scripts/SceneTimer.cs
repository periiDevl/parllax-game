using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTimer : MonoBehaviour
{
    public float scene_Time;
    public string scene_name;

    void Update()
    {
        scene_Time -= Time.deltaTime;
        if (scene_Time <= 0)
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
