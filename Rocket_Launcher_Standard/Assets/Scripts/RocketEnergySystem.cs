using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class RocketEnergySystem :Rocket
{
    protected override void FuelAdd(float amount)
    {
        fillamount += amount;

        Debug.Log(fillamount);
    }
    protected override void FilledImage()
    {
        Vector2 vector2Transform = FilledTransform.sizeDelta;
        vector2Transform.x = fillamount;
        if (fillamount > 100)
        {
            return;
        }
        else
        {
            FilledTransform.sizeDelta = vector2Transform;
        }
    }
}
