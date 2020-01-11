using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileGrenade : MonoBehaviour
{
    public float blastRadius;
    public float explosionForce;
    public LayerMask explosionLayers;
    private Collider[] hitColliders;
    public float speed;
    Rigidbody rb;
    float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0;
        //rb.velocity = -transform.forward * speed;
        //rb.AddForce(-transform.forward*2, ForceMode.Impulse);
    }
    void Update()
    {
        
        timer += Time.deltaTime;
        DoExplosion();
    }


    void DoExplosion()
    {
        if (timer >= 5)
        {
            hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
            foreach (Collider hitcol in hitColliders)
            {
                if (hitcol.GetComponent<Rigidbody>() != null)
                {
                    hitcol.GetComponent<Rigidbody>().isKinematic = false;
                    hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, blastRadius, 0.2f, ForceMode.Impulse);
                }

            }
            Destroy(gameObject);
        }
    }
}