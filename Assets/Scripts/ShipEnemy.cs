using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy : MonoBehaviour
{
    [SerializeField] int m_scorePenalty = 200;
    [SerializeField] float m_speed = 1.0f;
    [SerializeField] float m_RotationSpeed = 1.0f;
    [SerializeField] GameObject m_player = null;

    void Start()
    {
        if (m_player == null)
        {
            m_player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    void Update()
    {
        float targetX = m_player.transform.position.x - transform.position.x;
        if (targetX >= 1.0f)
        {
            //move right
            transform.rotation = Quaternion.AngleAxis(30.0f, Vector3.forward);
        }
        else if (targetX <= -1.0f)
        {
            //move left
            transform.rotation = Quaternion.AngleAxis(-30.0f, Vector3.forward);
        }
        else
        {
            //move down
            transform.rotation = Quaternion.AngleAxis(0.0f, Vector3.forward);
        }

        transform.position -= transform.up * m_speed * Time.deltaTime;

        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //then we hit a player, tell the game to deduct them
            Game.Instance.HitPlayer(m_scorePenalty);
        }
    }
}
