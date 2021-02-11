using UnityEngine;
using System.Collections;
public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
public float camZ; 
    void Awake()
    {
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {

        if (POI == null) return; 

    // Get the position of the poi
Vector3 destination = POI.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // Force destination.z to be camZ to keep the camera far enough away
        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
    }
}
