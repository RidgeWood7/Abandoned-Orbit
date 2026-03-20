using UnityEngine;
using UnityEngine.UI;

    


public class BurnBright : MonoBehaviour
{
    [Range(0, 1)]
    public float brightness = 1f;
    public Slider brightnessSlider;
    private const string BrightnessPrefKey = "Brightness";

    private void Start()
    {
        brightness = PlayerPrefs.GetFloat(BrightnessPrefKey, 1f);
        brightnessSlider.value = brightness;
        brightnessSlider.minValue = 0f;
        brightnessSlider.maxValue = 1f;
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        brightness = value;
        PlayerPrefs.SetFloat(BrightnessPrefKey, brightness);
        PlayerPrefs.Save();

    }
}
