using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    private float shakeDecay,
                  shakeIntensity;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private bool shaking;
    private Transform transformAtOrigin;

    void OnEnable()
    {
        transformAtOrigin = transform;
    }

    // Update is called once per frame
    // Rotates camera to create a skaing effect
    void Update()
    {
        if (!shaking)
            return;
        if (shakeIntensity > 0f)
        {
            transformAtOrigin.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            transformAtOrigin.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .2f);
            shakeIntensity -= shakeDecay;
        }
        else
        {
            shaking = false;
            transformAtOrigin.localPosition = originPosition;
            transformAtOrigin.localRotation = originRotation;
        }

    }
    // Screen Shake function
    public void Shake(float decayValue, float intensityValue)
    {
        if (!shaking)
        {
            originPosition = transformAtOrigin.localPosition;
            originRotation = transformAtOrigin.localRotation;
        }
        shaking = true;
        shakeDecay = decayValue / 100;
        shakeIntensity = intensityValue / 100;
    }
    // you can call in the function with this line of code
    // Camera.main.GetComponent<ScreenShake>().Shake(0.2f, 4);
}