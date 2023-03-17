using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.ShaderGraph;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [SerializeField]
    private BubbleEnums.BubbleColor bubbleColor;
    private Projectile collidedProjectile;

    private void Awake()
    {
        rb.AddRelativeForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Projectile>())
        {
            //Debug.Log(transform.position);
            collidedProjectile = col.gameObject.GetComponent<Projectile>();
            
            if (collidedProjectile.rb.isKinematic)
            {
                //onBubbleHitEvent.Invoke(gameObject, bubbleColor);
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
                rb.isKinematic = true;
            }

            foreach (GameObject go in GameManager.instance.bubblesList)
            {
                if (CheckForDistance(go.transform.position, transform.position) < 0.7f)
                {
                    if (go.GetComponent<Projectile>().bubbleColor == collidedProjectile.bubbleColor)
                    {
                        GameManager.instance.sameColorList.Add(go);
                    }
                }
            }


            foreach (GameObject go in GameManager.instance.sameColorList)
            {
                Destroy(go);
                GameManager.instance.bubblesList.Remove(go);
            }
            Destroy(gameObject);
            GameManager.instance.sameColorList.Clear();
        }
    }
    private float CheckForDistance(Vector3 firstPos, Vector3 secondPos)
    {
        float distance = Vector3.Distance(firstPos, secondPos);
        return distance;
    }
}
