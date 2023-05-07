using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 25f;
    public float startIntensity = 0f;
    public float maxIntensity = 0.5f;
    public float intensitySpeed = 0.1f;

    private float elapsedTime = 0f;
    private float currentIntensity = 0f;
    private Vector3 originalPosition;

    private bool shaking = false;
    private float startTime = 0f;
    private float shakeDuration = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shaking)
        {
            // Si la cam�ra tremble, on calcule l'intensit� actuelle du tremblement
            float shakeTime = Time.time - startTime;
            if (shakeTime <= shakeDuration)
            {
                currentIntensity = Mathf.Lerp(startIntensity, maxIntensity, shakeTime / shakeDuration);
                Vector3 randomOffset = Random.insideUnitCircle * currentIntensity;
                transform.localPosition = originalPosition + randomOffset;
            }
            else
            {
                // Si le tremblement est termin�, on r�initialise la position de la cam�ra
                transform.localPosition = originalPosition;
                shaking = false;
            }
        }
        else
        {
            // Si la cam�ra ne tremble pas, on v�rifie si le temps �coul� est sup�rieur � 40 secondes
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 40f)
            {
                // Si oui, on commence � faire trembler la cam�ra pendant 25 secondes
                shaking = true;
                startTime = Time.time;
                shakeDuration = duration;
            }
        }
    }
}
