using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 50;
    [Range(0, 0.01f)]
    public float time = 0.001f;
    public Material DestroyedMaterial;
    private MeshRenderer MeshRenderer;
    [Header("OTHER")]
    public bool dissulveMatrial = true;

    float value = -0.8f;
    private void Start()
    {
        DestroyedMaterial.SetFloat("_Visibility", value);
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0)
        {
            TakeMjorEffect();
        }
        
    }

    private void Update()
    {
        if (health <= 0 && value < 1)
        {
            value = value + time;
            DestroyedMaterial.SetFloat("_Visibility", value);
        }
    }

    private void TakeMjorEffect()
    {
        MeshRenderer.material = DestroyedMaterial;
        
    }


}
