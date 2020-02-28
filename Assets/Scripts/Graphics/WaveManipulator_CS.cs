using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManipulator_CS : MonoBehaviour
{
    [Header("Wave0")]
    [SerializeField] float m_wave0FrequencyThreshhold = 0.0f;
    public int m_bar0Band = 0;
    bool m_bar0CycleComplete = true;

    [Space]
    [Header("Wave1")]
    [SerializeField] float m_wave1FrequencyThreshhold = 0.0f;
    public int m_bar1Band = 0;
    bool m_bar1CycleComplete = true;

    [Space]
    [Header("Wave2")]
    [SerializeField] float m_wave2FrequencyThreshhold = 0.0f;
    public int m_bar2Band = 0;
    bool m_bar2CycleComplete = true;

    [Space]
    [Header("Wave3")]
    [SerializeField] float m_wave3FrequencyThreshhold = 0.0f;
    public int m_bar3Band = 0;
    bool m_bar3CycleComplete = true;


    [SerializeField] [Range(0.0f, 200.0f)] float multiplier = 1.0f;

    Material m_material = null;
    float m_waveIntensity = 1.0f;
    void Start()
    {
        m_material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        UpdateDensity0();
        UpdateDensity1();
        UpdateDensity2();
        UpdateDensity3();
    }

    private void OnPreRender()
    {
        GL.wireframe = true;
    }

    private void OnPostRender()
    {
        GL.wireframe = false;
    }

    void UpdateDensity0()
    {
        if (AudioPeer_CS.m_bandBuffer[m_bar0Band] > m_wave0FrequencyThreshhold && m_bar0CycleComplete)
        {
            if (m_bar0CycleComplete)
            {
                m_material.SetFloat("Vector1_8F67339F", m_bar0Band * multiplier);
                m_bar0CycleComplete = false;
            }
        }
        if (AudioPeer_CS.m_bandBuffer[m_bar0Band] < m_wave0FrequencyThreshhold && !m_bar0CycleComplete)
        {
            m_bar0CycleComplete = true;
        }
    }

    void UpdateDensity1()
    {
        if (AudioPeer_CS.m_bandBuffer[m_bar1Band] > m_wave1FrequencyThreshhold && m_bar1CycleComplete)
        {
            if (m_bar1CycleComplete)
            {
                m_material.SetFloat("Vector1_BBE35185", m_bar1Band * multiplier);
                m_bar1CycleComplete = false;
            }
        }
        if (AudioPeer_CS.m_bandBuffer[m_bar1Band] < m_wave1FrequencyThreshhold && !m_bar1CycleComplete)
        {
            m_bar1CycleComplete = true;
        }
    }

    void UpdateDensity2()
    {
        if (AudioPeer_CS.m_bandBuffer[m_bar2Band] > m_wave2FrequencyThreshhold && m_bar2CycleComplete)
        {
            if (m_bar2CycleComplete)
            {
                m_material.SetFloat("Vector1_F5C92CBB", m_bar2Band * multiplier);
                m_bar2CycleComplete = false;
            }
        }
        if (AudioPeer_CS.m_bandBuffer[m_bar2Band] < m_wave2FrequencyThreshhold && !m_bar2CycleComplete)
        {
            m_bar2CycleComplete = true;
        }
    }

    void UpdateDensity3()
    {
        if (AudioPeer_CS.m_bandBuffer[m_bar3Band] > m_wave3FrequencyThreshhold && m_bar3CycleComplete)
        {
            if (m_bar3CycleComplete)
            {
                m_material.SetFloat("Vector1_C3489B25", m_bar3Band * multiplier);
                m_bar3CycleComplete = false;
            }
        }
        if (AudioPeer_CS.m_bandBuffer[m_bar3Band] < m_wave3FrequencyThreshhold && !m_bar3CycleComplete)
        {
            m_bar3CycleComplete = true;
        }
    }
}
