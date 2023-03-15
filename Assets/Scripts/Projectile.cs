using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool targetHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Projectile>())
        {
            if (col.gameObject.GetComponent<Projectile>().rb.isKinematic)
            {                
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0f;
                rb.isKinematic = true;
                transform.SetParent(col.transform);
                
                if (col.gameObject.transform.childCount >= 3)
                {
                    Destroy(col.gameObject);
                    Destroy(this);
                }
            }
        }
    }
}
