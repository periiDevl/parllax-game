using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public Transform player;
    public float dist;
    public string s_name;
    public KeyCode key = KeyCode.T;
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < dist && Input.GetKeyDown(key))
        {
            SceneManager.LoadScene(s_name);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, dist);
    }
}
