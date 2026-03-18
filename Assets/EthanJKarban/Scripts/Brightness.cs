using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.HighDefinition;

public class Brightness : MonoBehaviour
{
    public Slider slide;

    public PostProcessProfile lighting;
    public PostProcessLayer postProcessLayer;

    AutoExposure exposed;
    void Start()
    {
        lighting.TryGetSettings(out exposed);
        AdjustBrightness(slide.value);
    }

    public void AdjustBrightness(float value)
    {
        if(value != 0)
        {
            exposed.keyValue.value = value;
        }
        else        {
            exposed.keyValue.value = .05f;
        }

    }
}
