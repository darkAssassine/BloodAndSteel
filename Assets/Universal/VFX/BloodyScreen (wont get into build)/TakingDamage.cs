using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakingDamage : MonoBehaviour
{
    public float intensity = 0;

    PostProcessVolume _volume;
    Vignette _vignette;

    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if(!_vignette)
        {
            print("error, vignette empty");
        }

        else
        {
            _vignette.enabled.Override(false);
        }

        StartCoroutine(TakingDamageEffect());
    }

    private IEnumerator TakingDamageEffect()
    {
        intensity = 0.4f;

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.4f);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0) intensity = 0;

            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.01f);
        }

        _vignette.enabled.Override(false);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
