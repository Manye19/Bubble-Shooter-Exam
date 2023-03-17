using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubbleParent;
    public List<GameObject> bubbleSpawnpoints = new();
    
    private GameObject projectileGo;
    private GameObject instantiatedObject;
    private Rigidbody2D instantiatedObjectRb;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in bubbleSpawnpoints)
        {
            projectileGo = GameManager.instance.RandomProjectile();
            instantiatedObject = Instantiate(projectileGo, go.transform.position, go.transform.rotation); 
            instantiatedObject.transform.SetParent(bubbleParent.transform);
            GameManager.instance.bubblesList.Add(instantiatedObject);
            instantiatedObjectRb = instantiatedObject.GetComponent<Rigidbody2D>();
            instantiatedObjectRb.velocity = Vector2.zero;
            instantiatedObjectRb.angularVelocity = 0f;
            instantiatedObjectRb.isKinematic = true;

            // Destroy spawn points
            Destroy(go.transform.parent.gameObject);
        }
    }
}
