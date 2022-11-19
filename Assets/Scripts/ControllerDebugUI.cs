using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerDebugUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI positionText;
    [SerializeField] TextMeshProUGUI lastSecondMovement;
    [SerializeField] TextMeshProUGUI last4SecondsMovement;

    [SerializeField] ControllerInfo info;



    // Update is called once per frame
    void Update()
    {
        positionText.text = "p: " + info.controllerPosition.ToString();
        lastSecondMovement.text = "Last 1:" + info.GetMovementLastSeconds(1f);
        last4SecondsMovement.text = "Last 4:" + info.GetMovementLastSeconds(4f);
    }
}