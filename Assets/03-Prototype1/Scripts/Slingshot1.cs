using UnityEngine;
using System.Collections;
public class Slingshot1 : MonoBehaviour
{
    public GameObject launchPoint;
    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint1"); //
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false
        ); // b
    }
    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true
        ); // b
    }
    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false
        ); // b
    }
}
