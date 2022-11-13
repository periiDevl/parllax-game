using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickable : MonoBehaviour
{
    public Rigidbody Rigid;
    public void Start()
    {
        Rigid = transform.GetComponent<Rigidbody>();
    }
    public void pickup(Transform parent)
    {
        transform.SetParent(parent);
        Rigid.isKinematic = true;
    }
    public void drop()
    {
        Rigid.isKinematic = false;

    }
}
