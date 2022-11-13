using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    float Range = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    pickable Pickable_object;
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Range))
        {
            Pickable_object = hit.transform.GetComponent<pickable>();
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Pickable_object.pickup(transform);
            } 
            

            
        }
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            transform.DetachChildren();
            Pickable_object.drop();
        }
    }

    

    
}
