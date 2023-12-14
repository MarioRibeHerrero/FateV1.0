using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static System.TimeZoneInfo;

public class RoundCristal : MonoBehaviour
{
    //Color lerp
    [SerializeField] float timeBetwenShoots = 5f; 
    private Color defaultColor;
    private Color targetColor = Color.red;
    private float transitionTimer = 0f;


    [SerializeField] GameObject proyectile;
    private Transform player;

    private MeshRenderer meshRenderer;

    [SerializeField] int proyectileSpeed;

    private bool shooting;
    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        meshRenderer = GetComponent<MeshRenderer>();
    }


    private void Update()
    {
       ShootAnim();
    }
    private void ShootAnim()
    {
        
        // Increment the transition timer
        transitionTimer += Time.deltaTime;

        // Calculate the lerp factor (how much of the transition is complete)
        float lerpFactor = Mathf.Clamp01(transitionTimer / timeBetwenShoots);

        // Lerp between the default color and the target color
        Color lerpedColor = Color.Lerp(defaultColor, targetColor, lerpFactor);

        meshRenderer.material.color = lerpedColor;

        if(lerpFactor == 1)
        {
            //reiniciamos el "Color"
            transitionTimer = 0f;

            Shoot();
        }
    }

    private void Shoot()
    {

            GameObject instantiatedObject = Instantiate(proyectile, transform.position, Quaternion.identity);

            // Get the Rigidbody component of the instantiated object
            Rigidbody rb = instantiatedObject.GetComponent<Rigidbody>();

            if (rb != null && proyectile != null)
            {
                // Calculate the direction towards the player
                Vector3 direction = (player.position - instantiatedObject.transform.position).normalized;

                // Apply force in the direction towards the player
                rb.AddForce(direction * proyectileSpeed, ForceMode.Impulse);
            }
        
    }

}
