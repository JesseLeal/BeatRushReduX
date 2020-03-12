using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessManipulator_CS : MonoBehaviour
{
    public GameObject m_levelRef = null;
    Level_CS m_level = null;

    PostProcessVolume m_ppVolume = null;

    Vignette m_vignetteLayer = null;
    float m_vignIntensityMultiplier = 2.0f;

    [Header("Wave0")]
    [SerializeField] float m_wave0FrequencyThreshhold = 0.0f;
    public int m_bar0Band = 0;
    bool m_bar0CycleComplete = true;

    void Start()
    {
        m_ppVolume = GetComponent<PostProcessVolume>();
        m_ppVolume.profile.TryGetSettings(out m_vignetteLayer);
        // TODO: change the vignette color tothe level color via it's diffuculty
    }

    void Update()
    {
        //if (AudioPeer_CS.m_bandBuffer[m_bar0Band] > m_wave0FrequencyThreshhold && m_bar0CycleComplete)
        //{
        //    if (m_bar0CycleComplete)
        //    {
        //        m_vignetteLayer.intensity.value = m_bar0Band * m_vignIntensityMultiplier;
        //        m_bar0CycleComplete = false;
        //    }
        //}
        //if (AudioPeer_CS.m_bandBuffer[m_bar0Band] < m_wave0FrequencyThreshhold && !m_bar0CycleComplete)
        //{
        //    m_bar0CycleComplete = true;
        //}
        //m_vignetteLayer.intensity.value = Mathf.Sin(Time.time);
    }
}
