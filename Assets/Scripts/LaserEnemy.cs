using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    //laser enemy should peek down, wait for a sec, then shoot
    [SerializeField] float m_spawnTime = 1.0f;
    [SerializeField] float m_waitTime = 2.0f;
    [SerializeField] float m_speed = 0.5f;
    [SerializeField] GameObject m_laser = null;

    private Vector3 m_movement;
    private bool m_canFire = false;
    private bool m_retreat = false;

    void Start()
    {
        m_movement = new Vector3(0.0f, -m_speed, 0.0f);
    }
    
    void Update()
    {
        if (m_spawnTime >= 0.0f)
        {
            transform.position += m_movement * Time.deltaTime;
            m_spawnTime -= Time.deltaTime;
        }
        else if (m_waitTime > 0.0f)
        {
            m_waitTime -= Time.deltaTime;
            if (m_waitTime <= 0.0f)
            {
                m_canFire = true;
            }
            //should it squash and stretch right before firing?
        }
        else if (m_canFire)
        {
            Fire();
            StartCoroutine(FireRoutine());
        }

        if (m_retreat)
        {
            transform.position -= m_movement * Time.deltaTime;
        }
    }

    public void Fire()
    {
        m_canFire = false;
        m_laser.SetActive(true);
        //but should the hitbox logic be here? or in a separate script?
    }

    private IEnumerator FireRoutine()
    {
        //make a sound, shoot the laser
        m_canFire = false;
        m_laser.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        m_laser.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        m_retreat = true;
        Destroy(this.gameObject, 3.0f);
    }
}