using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;


    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }




    void Shoot()
    {


        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);
            ///! = is not
            enemy enemy = hit.transform.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }// Start is called before the first frame update
    void Start()
    {
        
    }


}
