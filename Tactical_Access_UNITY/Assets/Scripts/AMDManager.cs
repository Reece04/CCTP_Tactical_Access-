using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class AMDManager : MonoBehaviour
{
    public Volume volume;
    public int currentNo = 0;

    [SerializeField] private GameObject LowAMD;
    [SerializeField] private GameObject ModerateAMD;
    [SerializeField] private GameObject SevereAMD;

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
        if (volume.profile.TryGet(out ColorAdjustments amd))
        {
            colorAdjustments = amd;
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
                LowAMD.SetActive(false);
                ModerateAMD.SetActive(false);
                SevereAMD.SetActive(false);
                break;

            case 1:
                LowAMD.SetActive(true);
                ModerateAMD.SetActive(false);
                SevereAMD.SetActive(false);
                break;

            case 2:
                LowAMD.SetActive(false);
                ModerateAMD.SetActive(true);
                SevereAMD.SetActive(false);
                break;

            case 3:
                LowAMD.SetActive(false);
                ModerateAMD.SetActive(false);
                SevereAMD.SetActive(true);
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