using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuMusic : MonoBehaviour{

    public AudioMixerGroup Mixer;

    public void ToggleVolume(Toggle Tog) {
        if (Tog.isOn) {
            Mixer.audioMixer.SetFloat("MasterVolume", 0);
        }
        else {
            Mixer.audioMixer.SetFloat("MasterVolume", -80);
        }
    }
    public void VolumeSlider(Slider SliderVolume) {
        Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, SliderVolume.value));
    }
    public void MusicSlider(Slider SliderMusic) {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, SliderMusic.value));
    }
    public void EffectsSlider(Slider SliderEffects) {
        Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, SliderEffects.value));
    }
}
