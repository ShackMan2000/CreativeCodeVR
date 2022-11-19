using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleController : MonoBehaviour
{

    // Listen to change in thrust
    // Adjust Particle values


  
    [SerializeField]
    private ParticleSystem sys;



    [SerializeField]
    private float minStartSpeed, maxStartSpeed;


    [SerializeField]
    private Vector3 minPosition, maxPosition;

    [SerializeField]
    private float minEmission, maxEmission;

    private ParticleSystem.EmissionModule sysEmit;


    private ParticleSystem.MainModule sysMain;

    public bool inDebugMode;

    [SerializeField] float checkInterval = 0.1f;
    float checkCounter;

    private void OnEnable()
    {
        sysEmit = sys.emission;

        sysMain = sys.main;
    }

    private void Update()
    {
        checkCounter += Time.deltaTime;
        if(checkCounter >= checkInterval)
        {
            checkCounter = 0f;
        }
    }


    private void SetStartSpeed(float thrustInPercent)
    {  
        float speed = thrustInPercent * maxStartSpeed + (1f - thrustInPercent) * minStartSpeed;

        sysMain.startSpeed = speed;
    }




    private void SetPosition(float thrustInPercent)
    {
        Vector3 pos = thrustInPercent * maxPosition + (1f - thrustInPercent) * minPosition;

        sys.transform.localPosition = pos;
    }



    private void SetEmission(float thrustInPercent)
    {
        float emission = thrustInPercent * maxEmission + (1f - thrustInPercent) * minEmission;
       
        sysEmit.rateOverTime = emission;

        if (inDebugMode)
            print(sysEmit.rateOverTime);
    }



    private void OnDisable()
    {
        //RocketThrustController.EvtThrustInputChanged -= SetStartSpeed;

        //if (minPosition != maxPosition)
        //    RocketThrustController.EvtThrustInputChanged -= SetPosition;

        //if (minEmission != maxEmission)
        //    RocketThrustController.EvtThrustInputChanged -= SetEmission;
    }



    [ContextMenu("SetMinPosition")]
    private void SetMinPosition()
    {
        minPosition = sys.transform.localPosition;
    }

    [ContextMenu("SetMaxPosition")]
    private void SetMaxPosition()
    {
        maxPosition = sys.transform.localPosition;
    }
}

