using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class arrowHandler : MonoBehaviour
{

    public GameObject goTarget;
    public GameObject controller;
    

    void Update()
    {
        //Vector3 v = goTarget.transform.position;
        //v.z = 0f;



        //this.transform.LookAt(transform.position + transform.forward, v - transform.position);

        //Vector3 targetPosLocal = controller.transform.InverseTransformPoint(goTarget.transform.position);
        //float targetAng = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg - 90;

        //this.transform.eulerAngles = new Vector3(0, 0, targetAng);

        Vector3 tmpVec = controller.transform.InverseTransformPoint(goTarget.transform.position);

        float angtoTar = Mathf.Atan2(tmpVec.x, tmpVec.z) * Mathf.Rad2Deg;
        angtoTar += 180.0f;
        this.transform.localEulerAngles = new Vector3(90, angtoTar, 0);
    }


}

