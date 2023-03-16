using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    private bool targetHit;

    public Rigidbody2D rb;
    
    [SerializeField]
    private BubbleEnums.BubbleColor bubbleColor;

    public BubbleHitEvent onBubbleHitEvent = new(); 
    
    private void Awake()
    {
        rb.AddRelativeForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == GameManager.instance.bubbleTilemap.gameObject)
        {
            //Debug.Log(bubbleColor);
            Debug.Log(transform.position);
            
            Vector3Int lastPosHit = new Vector3Int(Mathf.FloorToInt(transform.position.x), 
                Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(transform.position.z));
            onBubbleHitEvent.Invoke(bubbleColor, lastPosHit);
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
            //transform.SetParent(col.transform);
            
            Destroy(this.gameObject);
        }
    }
}
