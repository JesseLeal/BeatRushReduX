using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleManipulator_CS : MonoBehaviour
{
    ParticleSystem m_ps = null;
    void Start()
    {
        m_ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }
}
