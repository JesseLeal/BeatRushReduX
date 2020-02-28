using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 100.0f;
    [SerializeField] float m_invincibleTime = 2.0f;

    private bool m_left = false;
    private bool m_right = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        m_left = false;
        m_right = false;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_left = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_right = true;
        }

        if (m_left && !m_right)
        {
            transform.position -= new Vector3(m_speed, 0.0f, 0.0f) * Time.deltaTime;
        }
        else if (m_right && !m_left)
        {
            transform.position += new Vector3(m_speed, 0.0f, 0.0f) * Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), transform.position.y, 0.0f);
    }

    public void Hit()
    {
        StartCoroutine(HitRoutine());
    }

    private IEnumerator HitRoutine()
    {
        //play the I've been hit sound, make them flash, come back in a fixed time
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(m_invincibleTime);

        GetComponent<Collider2D>().enabled = true;
    }
}
