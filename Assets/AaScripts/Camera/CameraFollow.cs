using Cinemachine;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;  
    [SerializeField] float smoothTime = 0.3f;  
    [SerializeField] LayerMask obstacleLayer;  


    [SerializeField] float xDistance;
    [SerializeField] float yDistanceDown, yDistanceUp;


    private Vector3 followYPos;
    CinemachineVirtualCamera cam;


    [SerializeField] float xOffset, yOffset;
    private Vector3 velocity = Vector3.zero; 



    [SerializeField] float zoomSpeed;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;

    public float targetZoom;



    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        targetZoom = cam.m_Lens.Orthographic ? cam.m_Lens.OrthographicSize : cam.m_Lens.FieldOfView;
        followYPos.x = player.transform.position.x;
        followYPos.y = player.transform.position.y;
        cam.Follow = null;

    }
    void LateUpdate()
    {
        FluidZoom();
        RayCasts();
    }


    private void RayCasts()
    {

        
        if (Physics.Raycast(player.transform.position, Vector3.up, yDistanceUp, obstacleLayer) || Physics.Raycast(player.transform.position, -Vector3.up, yDistanceDown, obstacleLayer))
        {

        }
        else
        {
            followYPos.y = player.transform.position.y;

        }

        if (Physics.Raycast(player.transform.position, Vector3.right, xDistance, obstacleLayer) || Physics.Raycast(player.transform.position, -Vector3.right, xDistance, obstacleLayer))
        {

        }
        else
        {
            followYPos.x = player.transform.position.x;

        }

        if (GameManager.Instance.isPlayerAlive)
        {
            Vector3 targetPositionY = new Vector3(followYPos.x + xOffset, followYPos.y + yOffset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPositionY, ref velocity, smoothTime);
        }

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(player.transform.position, Vector3.right * xDistance, color: Color.green);
        Debug.DrawRay(player.transform.position, -Vector3.right * xDistance, color: Color.green);

        Debug.DrawRay(player.transform.position, Vector3.up * yDistanceUp, color: Color.green);
        Debug.DrawRay(player.transform.position, -Vector3.up * yDistanceDown, color: Color.green);
    }
    public void ZoomOut()
    {
        xDistance = 12.2f;
        yDistanceDown = 6;
        yDistanceUp = 7.7f;
        yOffset = 3f;
        targetZoom = 80;

    }
    public void ZoomIn()
    {
        xDistance = 7.8f;
        yDistanceDown = 1.7f;
        yDistanceUp = 6.5f;
        yOffset = 3f;
        targetZoom = 45;
    }
    private void FluidZoom()
    {

        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        // Smoothly interpolate between the current camera size and the targetZoom
        if (cam.m_Lens.Orthographic)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        }
        else
        {
            cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }
}
