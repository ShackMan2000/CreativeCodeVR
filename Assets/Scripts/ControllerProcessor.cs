using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerProcessor : MonoBehaviour
{

    [SerializeField] Transform head;
    [SerializeField] Transform controller;
    [SerializeField] ControllerInfo controllerInfo;

    float moveCheckCounter;
    Vector3 positionLastCheck;

    private void Update()
    {
        Vector3 controllerInHeadspace = head.InverseTransformPoint(controller.position);
        controllerInfo.controllerPosition = controllerInHeadspace;


        moveCheckCounter += Time.deltaTime;
        if(moveCheckCounter >= 0.1f)
        {
            moveCheckCounter = 0f;
            Vector3 movementAbsolute = new Vector3(Mathf.Abs(positionLastCheck.x - controller.transform.position.x),
                                       Mathf.Abs(positionLastCheck.y - controller.transform.position.y),
                                       Mathf.Abs(positionLastCheck.z - controller.transform.position.z));
            controllerInfo.AddMovementInfo(movementAbsolute);
            positionLastCheck = controller.transform.position;
        }
    }


}
