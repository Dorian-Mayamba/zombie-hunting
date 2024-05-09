using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        Debug.Log("Init slider "+slider);
    }

    public void TakeDamage(float amount)
    {
        slider.value-=amount;
    }

    public void InitHealth(float maxHeight)
    {
        slider.maxValue = maxHeight;
    }
}
