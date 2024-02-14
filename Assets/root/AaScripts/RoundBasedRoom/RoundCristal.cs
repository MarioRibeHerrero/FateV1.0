using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class RoundCristal : MonoBehaviour
{

    [SerializeField] GameObject cristalObj;
    [SerializeField] VisualEffect shootPointEffect;
    [SerializeField] GameObject shootingPoint;

    private Transform player;
    readonly float rotationSpeed = 5.0f;
    readonly float delay = 0.5f;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LineRenderer shoot;

    [SerializeField] LayerMask warningLayers, rayLayers;

    private Vector3 playerPos;

    private bool aboutToShoot, warkingRayCast;
    [SerializeField] float cristalDamage;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        //cristalObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

        lineRenderer.enabled = false;
        shoot.enabled = false;
    }

    private void Start()
    {

    }

    private void Update()
    {
        LookAtPlayer();

        if (warkingRayCast)
        {

            Ray ray = new Ray(shootingPoint.transform.position, shootingPoint.transform.up);

            RaycastHit hit;

            Physics.Raycast(ray, out hit, Mathf.Infinity, warningLayers);
            lineRenderer.SetPosition(0, shootingPoint.transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }



    private void LookAtPlayer()
    {
        if (!aboutToShoot)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            float xRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * delay).eulerAngles.x;

            Quaternion tY;
            if (player.position.x - transform.position.x < 0) tY = Quaternion.Euler(xRotation, -90, transform.rotation.z);
            else tY = Quaternion.Euler(xRotation, -270, transform.rotation.z);

            float yRotation = Quaternion.Lerp(transform.rotation, tY, rotationSpeed * Time.deltaTime * delay).eulerAngles.y;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, transform.rotation.z);

        }
    }

    public void Reset()
    {
        aboutToShoot = false;
        cristalObj.SetActive(true);
        cristalObj.GetComponent<CristalHealthManager>().Reset();
        cristalObj.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 90));

    }
    private void EnableWarning()
    {
        lineRenderer.enabled = true;
        warkingRayCast = true;
    }
    private void AboutToShoot()
    {
        aboutToShoot = true;
        lineRenderer.enabled = false;
        warkingRayCast = false;
    }
    private void Shoot()
    {


        aboutToShoot = false;
        shoot.enabled = true;
        Debug.Log("KJSAJHOD");
        Ray ray = new Ray(shootingPoint.transform.position, shootingPoint.transform.up);

        RaycastHit hit;
        RaycastHit hit2;

        Physics.Raycast(ray, out hit, Mathf.Infinity, rayLayers);


        shoot.SetPosition(0, shootingPoint.transform.position);
        shoot.SetPosition(1, hit.point);
        shootPointEffect.gameObject.transform.position = hit.point;
        shootPointEffect.transform.localScale = Vector3.one;
        shootPointEffect.Play();
        Debug.Log(hit.collider.name);

        Physics.Raycast(ray, out hit2, Mathf.Infinity, warningLayers);
        if (hit2.collider.GetComponent<PlayerHit>() != null)
        {
            Debug.Log(hit2.collider.transform.GetComponent<PlayerHit>());
            
            hit2.collider.transform.GetComponent<PlayerHit>().HitPlayer(new Vector3(0,0,0),0,0,cristalDamage,true);
        }

        Invoke(nameof(ShootLineToFalse), 0.2f);

    }

    private void ShootLineToFalse()
    {
        shoot.enabled = false;

    }



    public void Explote()
    {
        shootPointEffect.gameObject.transform.position = transform.position;
        shootPointEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        shootPointEffect.Play();
    }
}
