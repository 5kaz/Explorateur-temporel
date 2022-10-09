using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PastFutureSwitchPP : MonoBehaviour
{
    [SerializeField] public Material skyboxPast;
    [SerializeField] public Material skyboxPresent;
    private bool pastToFuture;
    private int startSwitch = -1;
    private float speed = 0.8f;
    Vignette vignette;
    LensDistortion lensDistortion;
    ChromaticAberration chromaticAberration;
    Bloom bloom;

    // Start is called before the first frame update
    void Start()
    {
        
        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
        vignette.intensity.value = 0.5f;
        volume.profile.TryGet<LensDistortion>(out lensDistortion);
        lensDistortion.intensity.value = 0.0f;
        volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        chromaticAberration.intensity.value = 0.0f;
        volume.profile.TryGet<Bloom>(out bloom);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (startSwitch)
        {
            case 0:
                vignette.intensity.value += 0.1f * speed;
                chromaticAberration.intensity.value += 0.5f * speed;
                lensDistortion.intensity.value -= 0.1f * speed;
                bloom.intensity.value += 5.0f * speed;

                if (vignette.intensity.value >= 0.9f || lensDistortion.intensity.value <= -0.9f)
                {
                    vignette.intensity.value = 0.9f;
                    lensDistortion.intensity.value = -0.9f;
                    chromaticAberration.intensity.value = 1.0f;
                    startSwitch = 1;
                }
                break;
            case 1:
                vignette.intensity.value -= 0.1f * speed;
                chromaticAberration.intensity.value -= 0.01f * speed;
                lensDistortion.intensity.value += 0.1f * speed;
                bloom.intensity.value -= 5.0f * speed;

                if (vignette.intensity.value <= 0.5f || lensDistortion.intensity.value >= 0.0f)
                {
                    vignette.intensity.value = 0.5f;
                    lensDistortion.intensity.value = 0.0f;
                    chromaticAberration.intensity.value = 0.0f;
                    
                    if (pastToFuture)
                    {
                        bloom.threshold.value = 1.0f;
                        bloom.intensity.value = 1.0f;
                    }
                    else
                    {
                        bloom.threshold.value = 0.8f;
                        bloom.intensity.value = 10.0f;
                    }

                    startSwitch = -1;
                }
                break;
            default:
                break;
        }


       
    }

    public void StartTransition(bool pastToFuture)
    {
        this.pastToFuture = pastToFuture;
        startSwitch = 0;

        if (pastToFuture)
        {
            RenderSettings.skybox = skyboxPresent;
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            RenderSettings.skybox = skyboxPast;
            DynamicGI.UpdateEnvironment();
        }
    }
}
