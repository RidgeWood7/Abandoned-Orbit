using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Brightness : MonoBehaviour
{
    public const string BRIGHTNESS = "Brightness";

    public Slider slide;

    public Volume lighting;

    void Start()
    {
        slide.value = PlayerPrefs.GetFloat(BRIGHTNESS, 0f);

        AdjustBrightness(slide.value);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(BRIGHTNESS, slide.value);
    }

    public void AdjustBrightness(float value)
    {
        if (lighting.sharedProfile.TryGet(out ColorAdjustments exposed))
        {
            exposed.postExposure.Override(value);
        }
    }
}
