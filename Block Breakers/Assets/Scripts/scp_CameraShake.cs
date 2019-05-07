using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scp_CameraShake : MonoBehaviour
{
    //Virtual Camera
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameranoise;

    public scp_Ball ballObject;

    //Initialization
    public float shakeDuration = 0.3f;
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2.0f;

    private float shakeElapsedTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        GetVirtualCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger - you can change it to what you want to activate the screenshake
        if (ballObject.hasCollidedWithBrick == true)
        {
            shakeElapsedTime = shakeDuration;
        }
        //If the cinemachine component is not set, avoid update
        if (virtualCamera != null || virtualCameranoise != null)
        {
            //If Camera shake is still playing
            if (shakeElapsedTime > 0)
            {
                //Set Cinemachine Camera Noise parameters
                virtualCameranoise.m_AmplitudeGain = shakeAmplitude;
                virtualCameranoise.m_FrequencyGain = shakeFrequency;

                //Update shaker timer
                shakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                //If camera shake is over reset values
                virtualCameranoise.m_AmplitudeGain = 0f;
                shakeElapsedTime = 0f;
                ballObject.hasCollidedWithBrick = false;
            }
        }

         
    }

    void GetVirtualCamera()
    {
        if (virtualCamera != null)
        {
            virtualCameranoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }
}
