using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] int m_scorePenalty = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //then we hit a player, tell the game to deduct them
            Game.Instance.HitPlayer(m_scorePenalty);
        }
    }
}