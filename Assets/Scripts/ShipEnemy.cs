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
        //this is close, but bad
        Vector3 target = m_player.transform.position - transform.position;
        float targetAngle = Mathf.Tan(target.y / target.x) * Mathf.Rad2Deg;
        //targetAngle = Mathf.Clamp(targetAngle, -30.0f, 30.0f);
        transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);

        transform.position -= transform.up * m_speed * Time.deltaTime;
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
