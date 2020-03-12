using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 100.0f;
    [SerializeField] float m_invincibleTime = 2.0f;
    [SerializeField] Sprite m_normalSprite = null;
    [SerializeField] Sprite m_hurtSprite = null;

    private bool m_left = false;
    private bool m_right = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        m_left = false;
        m_right = false;

        //debug
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                m_left = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                m_right = true;
            }
        }

        //Android
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (PlayerPrefs.GetInt("TiltControls", 0) == 0)
            {
                //touch controls
                foreach (Touch touch in Input.touches)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        m_left = true;
                    }

                    else
                    {
                        m_right = true;
                    }
                }
            }

            else
            {
                //tilt controls
                if (Input.acceleration.x > 0.05f)
                {
                    m_right = true;
                }
                else if (Input.acceleration.x < -0.05f)
                {
                    m_left = true;
                }
            }
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
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = m_hurtSprite;

        yield return new WaitForSeconds(m_invincibleTime);

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = m_normalSprite;
    }
}
