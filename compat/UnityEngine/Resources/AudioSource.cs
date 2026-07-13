using System;

namespace UnityEngine
{
    public class AudioSource : AudioBehaviour
    {
        public AudioClip clip { get; set; }
        public float volume { get; set; }
        public float pitch { get; set; }
        public bool loop { get; set; }
        public bool isPlaying => false;
        public bool playOnAwake { get; set; }
        public float time { get; set; }
        public int priority { get; set; }
        public float spatialBlend { get; set; }
        public float reverbZoneMix { get; set; }
        public float dopplerLevel { get; set; }
        public float spread { get; set; }
        public AudioRolloffMode rolloffMode { get; set; }
        public float minDistance { get; set; }
        public float maxDistance { get; set; }
        public bool mute { get; set; }
        public Audio.AudioMixerGroup outputAudioMixerGroup { get; set; }
        public void Play() { }
        public void Play(ulong delay) { }
        public void Stop() { }
        public void Pause() { }
        public void UnPause() { }
        public void PlayOneShot(AudioClip clip) { }
        public void PlayOneShot(AudioClip clip, float volumeScale) { }
        public void SetScheduledStartTime(double time) { }
        public void SetScheduledEndTime(double time) { }
        public void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve) { }
        public AnimationCurve GetCustomCurve(AudioSourceCurveType type) => null;
        public void GetOutputData(float[] samples, int channel) { }
        public void GetSpectrumData(float[] samples, int channel, FFTWindow window) { }
    }

    public enum FFTWindow
    {
        Rectangular = 0,
        Triangle = 1,
        Hamming = 2,
        Hanning = 3,
    }
}
