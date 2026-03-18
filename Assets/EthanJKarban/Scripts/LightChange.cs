using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour
{
    public Slider slider; // Grabs Slider
    public Light lightSource; // Grabs light
   
    void Start()
    {
        
    }

   
    void Update()
    {
        lightSource.intensity = slider.value; // Changes light with slider  DUHHHHHHH BRUHHH
    }
}
