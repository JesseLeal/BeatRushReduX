using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_CS : MonoBehaviour
{
    [SerializeField] eLevelDifficulty m_levelDiffuculty = 0;
    WaveManipulator_CS m_waveManipulator = null;

    public GameObject m_waveRef = null;
    Material m_material = null;

    string m_matColorShaderRef = "_Color";

    public enum eLevelDifficulty
    {
        EASY = 1,
        MEDIUM = 2,
        HARD = 3
    }

    public eLevelDifficulty LevelDifficulty { get { return m_levelDiffuculty; } }

    void Start()
    {
        m_waveManipulator = m_waveRef.GetComponent<WaveManipulator_CS>();
        if (!m_waveManipulator)
            Debug.Log("Failed to get Wave manipulator reference from game object!");
        m_material = m_waveManipulator.GetMaterial();
        if(!m_material)
            Debug.Log("Failed to get material reference from game object!");

        switch (m_levelDiffuculty)
        {
            case eLevelDifficulty.EASY:
                m_material.SetVector(m_matColorShaderRef, new Vector4(0.0f, 1.0f, 0.0f, 1.0f));
                break;
            case eLevelDifficulty.MEDIUM:
                m_material.SetVector(m_matColorShaderRef, new Vector4(0.0f, 0.0f, 1.0f, 1.0f));
                break;
            case eLevelDifficulty.HARD:
                m_material.SetVector(m_matColorShaderRef, new Vector4(1.0f, 0.0f, 0.0f, 1.0f));
                break;
            default:
                m_material.SetVector(m_matColorShaderRef, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
                Debug.Log("Unable to determine wave color in Level_CS::Start. Returning black as fallback.");
            break;
        }
    }
    
}
