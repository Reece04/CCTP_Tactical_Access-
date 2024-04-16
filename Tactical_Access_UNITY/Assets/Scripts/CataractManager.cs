using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CataractManager : MonoBehaviour
{
    public Volume volume;
    public DepthOfField DepthOfField;
    public int currentNo = 0;

    private void Update()
    {
        if (volume.profile.TryGet(out DepthOfField depthOfField))
        {
            UpdateDepthOfField(depthOfField);
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
}
