using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRemove : MonoBehaviour
{
    public List<GameObject> level;
    public List<GameObject> Spawnlevel;
    public Material Material;
    public LayerMask playerMask;
    public float time = 0.001f;
    float value = -0.8f;
    bool colided = false;
    private void Start()
    {
        Material.SetFloat("_Visibility", value);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != playerMask)
        {
            foreach (GameObject o in level)
            {
                o.SetActive(false);
            }
            foreach (GameObject o in Spawnlevel)
            {
                o.SetActive(true);
            }
            colided = true;
        }
    }

    private void Update()
    {
        if (colided && value < 1)
        {
            value = value + time * Time.deltaTime;
            Material.SetFloat("_Visibility", value);
        }
    }
}
