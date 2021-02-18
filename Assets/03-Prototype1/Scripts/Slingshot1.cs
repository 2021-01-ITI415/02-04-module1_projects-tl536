using UnityEngine;
using System.Collections;
public class Slingshot1 : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject prefabProjectile;
    public float velocityMult = 8f;
    public GameObject launchPoint;
    public Vector3 launchPos; // b
    public GameObject projectile; // b
    public bool aimingMode;
    private Rigidbody projectileRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint1"); 
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    void OnMouseEnter()
    {
        launchPoint.SetActive(true); 
    }
    void OnMouseExit()
    {
        launchPoint.SetActive(false); 
    }
    void OnMouseDown()
    {
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;

        projectileRigidbody = projectile.GetComponent<Rigidbody>(); 
        projectileRigidbody.isKinematic =
        true; 
    }
    void Update()
    {
       
        if (!aimingMode)
            return; 
        Vector3 mousePos2D =
        Input.mousePosition; 
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
       
float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        { 
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            projectile = null;
        }
    }
}
