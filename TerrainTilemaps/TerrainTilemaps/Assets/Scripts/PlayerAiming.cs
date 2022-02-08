using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAiming : MonoBehaviour
{
    
    public int MinPower = 0;
    public int MaxPower = 100;

    int currentPower, currentAngle;

    public SpriteRenderer AimSprite;
    public PlayerShooting shootScript;
   
 
    /*
    This section was implemented in order to use the game manager
    void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
         
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalculateAngle();
            CalculatePower();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // fire projectile
            shootScript.FireProjectile(currentPower);
            //AimSprite.transform.localPosition = new Vector2(1, 1);
            
        }

        if (Input.GetMouseButton(1))
        {
            CalculateAngle();
            CalculatePower();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            // fire projectile
            shootScript.FireProjectileBomb(currentPower);
            //AimSprite.transform.localPosition = new Vector2(1, 1);

        }

    }

    void CalculateAngle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        UpdateAngle((int)angle);
    }

    void UpdateAngle(int amount)
    {
        currentAngle = amount;
        AimSprite.transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    }

    void CalculatePower()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float distance = Vector3.Distance(mousePos, transform.position) * 18;
        UpdatePower((int)distance);
    }

    void UpdatePower(int amount)
    {
        currentPower = Mathf.Clamp(amount, MinPower, MaxPower);
        AimSprite.transform.localScale = new Vector2(currentPower / 18, currentPower / 18);
    }
}
