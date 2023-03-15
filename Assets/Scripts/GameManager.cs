using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
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

    [Header("Script References")]
    public PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void OnEnable()
    {
        playerControlScript.onBubbleShotEvent.AddListener(SwitchBubble);
    }

    public void SwitchBubble()
    {
        Debug.Log("Switch Bubble");
        selectedProjectile = RandomProjectile();
        projectileParentSprite.sprite = selectedProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
    }
    private GameObject RandomProjectile()
    {
        GameObject randomGo = projectilePrefabs[Random.Range(0, projectilePrefabs.Count)];
        return randomGo;
    }
}
