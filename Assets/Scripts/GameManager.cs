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
    public Transform barrelParent;
    public SpriteRenderer projectileParentSprite;
    public GameObject selectedProjectile;
    public List<GameObject> projectilePrefabs = new();
    public List<Tile> colorTiles = new();
    public Tilemap bubbleTilemap;

    //private Dictionary<TileBase, TileData> dataFromTiles;

    [Header("Script References")]
    public PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize projectile (bubble) at game start
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
        
        // Switch Bubble tilemap every game start
        //bubbleTilemap.SetTiles();
        // dataFromTiles = new Dictionary<TileBase, TileData>();
        // foreach (var tileData in tileDatas)
        // {
        //     
        // }
    }

    private void OnEnable()
    {
        playerControlScript.onBubbleShotEvent.AddListener(SwitchBubble);
    }

    private void OnDisable()
    {
        playerControlScript.onBubbleShotEvent.RemoveListener(SwitchBubble);
        playerControlScript.projectileScript.onBubbleHitEvent.RemoveListener(BubbleTilemapHit);
    }

    public void SwitchBubble()
    {
        //Debug.Log("Switch Bubble");
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    public void BubbleTilemapHit(BubbleEnums.BubbleColor colorThrownHit, Vector3Int hitPos)
    {
        if (!bubbleTilemap.HasTile(hitPos))
        {
            bubbleTilemap.SetTile(hitPos, colorTiles[(int)colorThrownHit]);
        }
    }
    
    #region Functions
    private GameObject RandomProjectile()
    {
        // Creates and returns random gameObject from projectilePrefab List.
        GameObject randomGo = projectilePrefabs[Random.Range(0, projectilePrefabs.Count)];
        return randomGo;
    }

    private void CheckIfEmpty()
    {
        
    }
    #endregion
}
