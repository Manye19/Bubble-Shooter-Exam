using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [Header("Game References")]
    public SpriteRenderer projectileParentSprite;
    public GameObject selectedProjectile;
    public List<GameObject> projectilePrefabs = new();
    public List<GameObject> bubblesList = new();
    public List<GameObject> sameColorList = new();
    
    [Header("Script References")]
    public PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize projectile (bubble) at game start
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void OnEnable()
    {
        playerControlScript.onBubbleShotEvent.AddListener(SwitchBubble);
    }

    private void OnDisable()
    {
        playerControlScript.onBubbleShotEvent.RemoveListener(SwitchBubble);
    }

    public void SwitchBubble()
    {
        //Debug.Log("Switch Bubble");
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    #region Functions
    public GameObject RandomProjectile()
    {
        // Creates and returns random gameObject from projectilePrefab List.
        GameObject randomGo = projectilePrefabs[Random.Range(0, projectilePrefabs.Count)];
        return randomGo;
    }
    #endregion
}
