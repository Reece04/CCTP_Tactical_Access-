using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DRManager : MonoBehaviour
{
    public Volume volume;
    public int currentNo = 0;

    [SerializeField] private GameObject BackgroundRetinopathy;
    [SerializeField] private GameObject PreProliferativeRetinopathy;
    [SerializeField] private GameObject ProliferativeRetinopathy;

    [SerializeField] private Slider BrightnessSlider;
    [SerializeField] private float maxSliderAmount = 100f;
    private ColorAdjustments colorAdjustments;

    [SerializeField] private Slider ContrastSlider;
    [SerializeField] private Slider SaturationSlider;


    private void Update()
    {
        UpdateAMD();
    }

    private void Start()
    {
        if (volume.profile.TryGet(out ColorAdjustments dr))
        {
            colorAdjustments = dr;
        }
        else
        {
            Debug.LogError("Failed to get ColorAdjustments from volume profile.");
        }
    }

    private void UpdateAMD()
    {
        switch (currentNo)
        {
            case 0:
                BackgroundRetinopathy.SetActive(false);
                PreProliferativeRetinopathy.SetActive(false);
                ProliferativeRetinopathy.SetActive(false);
                break;

            case 1:
                BackgroundRetinopathy.SetActive(true);
                PreProliferativeRetinopathy.SetActive(false);
                ProliferativeRetinopathy.SetActive(false);
                break;

            case 2:
                BackgroundRetinopathy.SetActive(false);
                PreProliferativeRetinopathy.SetActive(true);
                ProliferativeRetinopathy.SetActive(false);
                break;

            case 3:
                BackgroundRetinopathy.SetActive(false);
                PreProliferativeRetinopathy.SetActive(false);
                ProliferativeRetinopathy.SetActive(true);
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
