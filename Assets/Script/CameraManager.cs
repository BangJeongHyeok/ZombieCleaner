using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [HideInInspector] public Camera MainCamera;

    private float CurrentShakingTime;
    private float ShakingTime;
    private float ShakingSize;
    private bool IsShaking;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShaking)
        {
            CurrentShakingTime += Time.deltaTime;
            if (CurrentShakingTime >= ShakingTime)
            {
                CurrentShakingTime = 0;
                ShakingTime = 0;
                ShakingSize = 0;
                IsShaking = false;
            }
            else
            {
                transform.localPosition = (Vector3)Random.insideUnitCircle * ShakingSize + transform.position;
            }
        }
        else
            transform.localPosition = new Vector3(0, 0.378f, 0);
    }

    public void ShakingCamera(float time, float shakesize)
    {
        CurrentShakingTime = 0;
        ShakingTime = time;
        ShakingSize = shakesize;
        IsShaking = true;
    }
}
