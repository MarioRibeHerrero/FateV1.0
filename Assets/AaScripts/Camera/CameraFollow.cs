using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;  // Reference to the player's transform
    [SerializeField] float smoothTime = 0.3f;  // Smoothing factor for Lerp
    [SerializeField] LayerMask obstacleLayer;  // Layer mask for obstacles
    [SerializeField] float xDistance;
    [SerializeField] float yDistanceDown, yDistanceUp;


    private Vector3 followYPos;


    [SerializeField] float xOffset, yOffset;
    private Vector3 velocity = Vector3.zero;  // Used for smoothing with Lerp


    private void Awake()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    void Update()
    {
      //  CameraFollowUpdate();


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



        Vector3 targetPositionY = new Vector3(followYPos.x + xOffset, followYPos.y + yOffset, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPositionY, ref velocity, smoothTime);


    }





    private void OnDrawGizmos()
    {
        Debug.DrawRay(player.transform.position, Vector3.right * xDistance, color: Color.green);
        Debug.DrawRay(player.transform.position, -Vector3.right * xDistance, color: Color.green);

        Debug.DrawRay(player.transform.position, Vector3.up * yDistanceUp, color: Color.green);
        Debug.DrawRay(player.transform.position, -Vector3.up * yDistanceDown, color: Color.green);
    }
}
