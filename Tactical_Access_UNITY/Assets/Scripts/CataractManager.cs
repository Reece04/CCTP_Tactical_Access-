using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CataractManager : MonoBehaviour
{
    public Volume volume;
    private DepthOfField DepthOfField;
    public int currentNo = 0;

    [SerializeField] private Slider BrightnessSlider;
    [SerializeField] private float maxSliderAmount = 100f;
    private ColorAdjustments colorAdjustments;

    [SerializeField] private Slider ContrastSlider;
    [SerializeField] private Slider SaturationSlider;


    private void Update()
    {
        if (volume.profile.TryGet(out DepthOfField depthOfField))
        {
            UpdateDepthOfField(depthOfField);
        }
    }

    private void Start()
    {
        if (volume.profile.TryGet(out ColorAdjustments ca))
        {
            colorAdjustments = ca;
        }
        else
        {
            Debug.LogError("Failed to get ColorAdjustments from volume profile.");
        }
    }

    private void UpdateDepthOfField(DepthOfField depthOfField)
    {
        switch (currentNo)
        {
            case 0:
                depthOfField.focusDistance.value = 100f;
                depthOfField.focalLength.value = 11f;
                depthOfField.aperture.value = 4f;
                break;

            case 1:
                depthOfField.focusDistance.value = 0.1f;
                depthOfField.focalLength.value = 4.8f;
                depthOfField.aperture.value = 1f;
                break;

            case 2:
                depthOfField.focusDistance.value = 0.1f;
                depthOfField.focalLength.value = 5f;
                depthOfField.aperture.value = 1f;
                break;

            case 3:
                depthOfField.focusDistance.value = 0.1f;
                depthOfField.focalLength.value = 11f;
                depthOfField.aperture.value = 4f;
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

    public void BrightnessSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.postExposure.value = localValue / 100;
    }

    public void ContrastSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.contrast.value = localValue / 100;
    }

    public void SaturationSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        colorAdjustments.saturation.value = localValue / 100;
    }
}
