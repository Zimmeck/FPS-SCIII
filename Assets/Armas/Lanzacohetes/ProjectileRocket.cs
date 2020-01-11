using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRocket : MonoBehaviour
{
    public float blastRadius;
    public float explosionForce;
    public LayerMask explosionLayers;
    private Collider[] hitColliders;
    public float speed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       rb.velocity = -transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DoExplosion(collision.contacts[0].point);
        Destroy(gameObject);
       
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);
        foreach (Collider hitcol in hitColliders)
        {
            if (hitcol.GetComponent<Rigidbody>() != null)
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, blastRadius, 0.2f, ForceMode.Impulse);
                hitcol.transform.GetComponent<Enemigo>().m_life -= 10;
            }
          
        }
    }
}
