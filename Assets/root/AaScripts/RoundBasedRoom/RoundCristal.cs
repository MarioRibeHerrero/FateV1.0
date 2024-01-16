using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
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

    [SerializeField] List<GameObject> proyectiles;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        CreateProyectilePool();
    }

    private void Update()
    {
       ShootAnim();
    }

    private void CreateProyectilePool()
    {
        for (int i = 0; i <= 1; i++)
        {
            
                GameObject go = Instantiate(proyectile);
            proyectiles.Add(go);
            go.SetActive(false);
        }
    }

    
    private void ShootAnim()
    {
        
        transitionTimer += Time.deltaTime;



        float progression = Mathf.Clamp01(transitionTimer / timeBetwenShoots);


        if(progression < 0.33 && progression > 0.66)
        {
            //linecast amarillo
        }



        if (progression == 1)
        {
            transitionTimer = 0f;
            Shoot();
        }
    }


    public void Reset()
    {
        transitionTimer = 0f;
        GetComponent<CristalHealthManager>().health = 20;
        
    }

    private void Shoot()
    {

        if(proyectiles.Count > 0)
        {

            int random = Random.Range(0, proyectiles.Count);

            if (!proyectiles[random].activeSelf)
            {
                Rigidbody rb = proyectiles[random].GetComponent<Rigidbody>();

                proyectiles[random].SetActive(true);
                proyectiles[random].transform.position = transform.position;

                rb.velocity = Vector3.zero;


                Vector3 direction = (player.position - proyectiles[random].transform.position).normalized;

                rb.AddForce(direction * proyectileSpeed, ForceMode.Impulse);

            }

        }
        
    }

}
