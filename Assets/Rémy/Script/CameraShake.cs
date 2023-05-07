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
            // Si la caméra tremble, on calcule l'intensité actuelle du tremblement
            float shakeTime = Time.time - startTime;
            if (shakeTime <= shakeDuration)
            {
                currentIntensity = Mathf.Lerp(startIntensity, maxIntensity, shakeTime / shakeDuration);
                Vector3 randomOffset = Random.insideUnitCircle * currentIntensity;
                transform.localPosition = originalPosition + randomOffset;
            }
            else
            {
                // Si le tremblement est terminé, on réinitialise la position de la caméra
                transform.localPosition = originalPosition;
                shaking = false;
            }
        }
        else
        {
            // Si la caméra ne tremble pas, on vérifie si le temps écoulé est supérieur à 40 secondes
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 40f)
            {
                // Si oui, on commence à faire trembler la caméra pendant 25 secondes
                shaking = true;
                startTime = Time.time;
                shakeDuration = duration;
            }
        }
    }
}
