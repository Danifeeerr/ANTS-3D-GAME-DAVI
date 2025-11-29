using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;

    public void OnEnable()
    {
        float dB = 0;

        mixer.GetFloat("MasterVolume", out dB);
        float linear = Mathf.Pow(10f, dB / 20f);
        MasterSlider.value = linear;

        mixer.GetFloat("MusicVolume", out dB);
        linear = Mathf.Pow(10f, dB / 20f);
        MusicSlider.value = linear;

        mixer.GetFloat("SFXVolume", out dB);
        linear = Mathf.Pow(10f, dB / 20);
        SFXSlider.value = linear;
    }
    public void SetMasterVolume()
    {
        float dB = Mathf.Log10(Mathf.Clamp(MasterSlider.value, 0.0001f, 1)) * 20;
        mixer.SetFloat("MasterVolume", dB);
    }

    public void SetMusicVolume()
    {
        float dB = Mathf.Log10(Mathf.Clamp(MusicSlider.value, 0.0001f, 1)) * 20;
        mixer.SetFloat("MusicVolume", dB);
    }
    
        public void SetSFXVolume()
    {
        float dB = Mathf.Log10(Mathf.Clamp(SFXSlider.value, 0.0001f, 1)) * 20;
        mixer.SetFloat("SFXVolume", dB);
    }
}
