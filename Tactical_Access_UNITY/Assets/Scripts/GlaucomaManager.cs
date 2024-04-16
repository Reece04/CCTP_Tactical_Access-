using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GlaucomaManager : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;
    public int currentNo = 0;

    [SerializeField] private Slider BrightnessSlider;
    [SerializeField] private float maxSliderAmount = 100f;
    private ColorAdjustments colorAdjustments;

    [SerializeField] private Slider ContrastSlider;
    [SerializeField] private Slider SaturationSlider;


    private void Update()
    {
        if (volume.profile.TryGet(out Vignette vignette))
        {
            UpdateGlaucoma(vignette);
        }
    }

    private void Start()
    {
        if (volume.profile.TryGet(out ColorAdjustments vig))
        {
            colorAdjustments = vig;
        }
        else
        {
            Debug.LogError("Failed to get ColorAdjustments from volume profile.");
        }
    }

    private void UpdateGlaucoma(Vignette vignette)
    {
        switch (currentNo)
        {
            case 0:
                vignette.intensity.value = 0f;
                vignette.smoothness.value = 0f;
                break;

            case 1:
                vignette.intensity.value = 0.5f;
                vignette.smoothness.value = 0.15f;
                break;

            case 2:
                vignette.intensity.value = 0.75f;
                vignette.smoothness.value = 0.2f;
                break;

            case 3:
                vignette.intensity.value = 0.75f;
                vignette.smoothness.value = 0.4f;
                break;

            default:
                // Handle default case here if needed
                break;
        }
    }

    public void SetCurrentNo(int newValue)
    {
        currentNo = newValue;
    }

    public void GBrightnessSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.postExposure.value = localValue / 100;
    }

    public void GContrastSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.contrast.value = localValue / 100;
    }

    public void GSaturationSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.saturation.value = localValue / 100;
    }
}
