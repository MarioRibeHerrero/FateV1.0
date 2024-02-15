using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
    using Cinemachine;
    using UnityEngine.InputSystem;

    public class CameraShakes : MonoBehaviour
    {

        public static CameraShakes instance;


        public CinemachineVirtualCamera vCam;
        
        private void Awake()
        {
            instance = this;

        }

        public void ShakeCamera(float intensity, float time)
        {
            
             vCam = GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        
            if (vCam != null)
            {
                CinemachineBasicMultiChannelPerlin noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                if (noise != null)
                {
                    noise.m_AmplitudeGain = intensity;
                    StartCoroutine(ResetCameraShake(time));                }
            }
        }   

        public IEnumerator ResetCameraShake(float time)
        {
            yield return new WaitForSeconds(time);
            CinemachineVirtualCamera vCam = GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        
            if (vCam != null)
            {
                CinemachineBasicMultiChannelPerlin noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                if (noise != null)
                {
                    noise.m_AmplitudeGain = 0f;
                }
            }
        }
    }
