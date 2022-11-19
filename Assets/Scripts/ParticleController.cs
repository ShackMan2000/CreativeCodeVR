using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
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

    [SerializeField] float minLifeTime, maxLifeTime;

    private ParticleSystem.EmissionModule sysEmit;


    [SerializeField] ControllerInfo rightControllerInfo;

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
            SetStartSpeed(Mathf.Clamp01(rightControllerInfo.HeightNormalized));
            SetLifeTime(Mathf.Clamp01(rightControllerInfo.HeightNormalized));
            SetColor(Mathf.Clamp01(rightControllerInfo.ForwardNormalized));

        }
    }


    void SetColor(float percent)
    {
        Color c = sysMain.startColor.color;
         Color.RGBToHSV(c, out float h, out float s, out float v);
        Color newColor = Color.HSVToRGB(percent, s, v); 
        sysMain.startColor = newColor;
    }

    private void SetStartSpeed(float thrustInPercent)
    {  
        float speed = thrustInPercent * maxStartSpeed + (1f - thrustInPercent) * minStartSpeed;

        sysMain.startSpeed = speed;
    }


    void SetLifeTime(float percent)
    {
        float lifeTime = Mathf.Lerp(minLifeTime, maxLifeTime, percent);

        sysMain.startLifetime = lifeTime;
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

