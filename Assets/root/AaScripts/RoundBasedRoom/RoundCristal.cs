using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundCristal : MonoBehaviour
{

    [SerializeField] GameObject cristalObj;
    [SerializeField] GameObject shootingPoint;

    private Transform player;
    readonly float rotationSpeed = 5.0f;
    readonly float delay = 0.5f;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LineRenderer shoot;

    [SerializeField] LayerMask collideLayerMaks;

    private Vector3 playerPos;

    private bool aboutToShoot, warkingRayCast;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        cristalObj.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 90));

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

            Physics.Raycast(ray, out hit, Mathf.Infinity, collideLayerMaks);
            lineRenderer.SetPosition(0, shootingPoint.transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }



    private void LookAtPlayer()
    {
        if (!aboutToShoot)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            float yRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * delay).eulerAngles.y;
            float xRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * delay).eulerAngles.x;
            float zRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * delay).eulerAngles.z;


            transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            playerPos = transform.rotation  * Vector3.up;
        }
    }

    public void Reset()
    {
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
    }
    private void Shoot()
    {
        lineRenderer.enabled = false;
        warkingRayCast = false;

        aboutToShoot = false;
        shoot.enabled = true;
        Debug.Log("KJSAJHOD");
        Ray ray = new Ray(shootingPoint.transform.position, shootingPoint.transform.up);

        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity, collideLayerMaks);
        shoot.SetPosition(0, shootingPoint.transform.position);
        shoot.SetPosition(1, hit.point);
        Debug.Log(hit.collider.name);
        Invoke(nameof(ShootLineToFalse), 0.2f);

    }

    private void ShootLineToFalse()
    {
        shoot.enabled = false;

    }
}
