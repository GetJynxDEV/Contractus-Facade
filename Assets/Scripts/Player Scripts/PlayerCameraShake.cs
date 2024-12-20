using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading;

public class PlayerCameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CVC;
    private float ShakeIntensity = 1f;
    private float shakeTime = 0.3f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin CMBMP;

    public static bool isFacade = false;

    void Start()
    {
        StopShake();
    }

    void Awake()
    {
        CVC = GetComponent<CinemachineVirtualCamera>();
        Debug.Log("CVC SECURED");
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin CMBMP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CMBMP.m_AmplitudeGain = ShakeIntensity;

        timer = shakeTime;
    }

    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin CMBMP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CMBMP.m_AmplitudeGain = 0;

        timer = 0;
    }

    void Update()
    {
        if (timer > 0)
        {

            timer -= Time.deltaTime;

            Debug.Log(timer);

            if (timer <=0)
            {
                StopShake();
            }
        }

        if (isFacade == true)
        {
            ShakeCamera();

            isFacade = false;

            Invoke("StopShake", 4);
        }

        
    }
}
