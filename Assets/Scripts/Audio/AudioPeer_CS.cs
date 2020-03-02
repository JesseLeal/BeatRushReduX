using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer_CS : MonoBehaviour
{
    AudioSource m_audioSource;
    public static float[] m_samples = new float[512];
    public static float[] m_freqBand = new float[4];
    public static float[] m_bandBuffer = new float[4];
    float[] m_bufferDecrease = new float[4];

    float[] m_freqBandHighest = new float[4];
    public static float[] m_audioBand = new float[4];
    public static float[] m_audioBandBuffer = new float[4];

    public static float m_amplitude;
    public static float m_amplitudeBuffer;
    float m_amplitudeHighest;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }
    
    void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;
        for (int i = 0; i < 4; i++)
        {
            currentAmplitude += m_audioBand[i];
            currentAmplitudeBuffer += m_audioBandBuffer[i];
        }
        if (currentAmplitude > m_amplitudeHighest)
        {
            m_amplitudeHighest = currentAmplitude;
        }
        m_amplitude = currentAmplitude / m_amplitudeHighest;
        m_amplitudeBuffer = currentAmplitudeBuffer / m_amplitudeHighest;

    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 4; i++)
        {
            if (m_freqBand[i] > m_freqBandHighest[i])
            {
                m_freqBandHighest = m_freqBand;
            }
            m_audioBand[i] = (m_freqBand[i] / m_freqBandHighest[i]);
            m_audioBandBuffer[i] = (m_bandBuffer[i] / m_freqBandHighest[i]);
        }
    }


    void BandBuffer()
    {
        for (int g = 0; g < 4; g++)
        {
            if (m_freqBand[g] > m_bandBuffer[g])
            {
                m_bandBuffer[g] = m_freqBand[g];
                m_bufferDecrease[g] = 0.005f;
            }
            if (m_freqBand[g] < m_bandBuffer[g])
            {
                m_bandBuffer[g] -= m_bufferDecrease[g];
                m_bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void GetSpectrumAudioSource()
    {
        m_audioSource.GetSpectrumData(m_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < m_freqBand.Length; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += m_samples[count] * (count + 1);
                count++;
            }

            average /= count;
            m_freqBand[i] = average * 10;
        }
    }
}
