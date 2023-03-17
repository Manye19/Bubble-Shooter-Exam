using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerControl : MonoBehaviour
{
    public Camera mainCamera;
    private InputMaster inputMaster;
    public Transform barrelParent;
    private GameObject projectileGo;
    [HideInInspector] public Projectile projectileScript;

    public BubbleShotEvent onBubbleShotEvent = new();
    
    private void Awake()
    {
        inputMaster = new InputMaster();
    }
    private void OnEnable()
    {
        inputMaster.Enable();
        inputMaster.Player.Shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }
    
    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    
    #region Functions
    private void Aim()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90f;
        
        // Clamped so as to limit the player; stop turning too much 
        rotationZ = Mathf.Clamp(rotationZ, -60, 60);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }    
    private void Shoot(InputAction.CallbackContext value)
    {
        //Debug.Log("Shoot!");
        if (projectileScript != null)
        {
            projectileScript = null;
        }
        projectileGo = Instantiate(GameManager.instance.selectedProjectile, barrelParent.position, barrelParent.rotation);
        projectileScript = projectileGo.GetComponent<Projectile>();
        onBubbleShotEvent.Invoke();
    }
    #endregion
}
