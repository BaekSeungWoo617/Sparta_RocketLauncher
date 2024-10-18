using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class RocketEnergySystem : MonoBehaviour
{
    [SerializeField] private Rocket rocket;

    private void Start()
    {
    RectTransform filledTransform = rocket.FilledTransformProperty;


    }
    private void Update()
    {
        FuelAdd(0.1f);
        FilledImage();
    }
    void FuelAdd(float amount)
    {
        rocket.FillAmount += amount;

        Debug.Log(rocket.FillAmount);
    }
      void FilledImage()
    {
        Vector2 vector2Transform = rocket.FilledTransformProperty.sizeDelta;
        vector2Transform.x = rocket.FillAmount;
        if (rocket.FillAmount > 100)
        {
            return;
        }
        else
        {
            rocket.FilledTransformProperty.sizeDelta = vector2Transform;
        }
    }
}
