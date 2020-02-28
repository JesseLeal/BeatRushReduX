using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    [SerializeField] int m_scorePenalty = 100;
    [SerializeField] float m_speed = 2.0f;

    private int angle = 0;
    private bool goingUp = false;

    void Start()
    {
        //I want it to pick a 120, 135, or 150 degree angle, then a direction.
        //pick a random number, 2 to 4, inclusive, times 15. randomly determine to flip or not
        //also take the same -8 to 8 x coord, combine the two, and we have the way to move

        angle = Random.Range(8, 11) * 15;
        int flip = Random.Range(0, 2);
        if (flip == 1)
        {
            angle *= -1;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0.0f) * Time.deltaTime * m_speed;
        if (Mathf.Abs(transform.position.x) >= 9.5f)
        {
            angle *= -1;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (transform.position.y <= -4.5f)
        {
            if (!goingUp)
            {
                goingUp = true;
                if (angle > 0)
                {
                    //change angle by the difference * 2
                    angle -= (angle - 90) * 2;
                }
                else
                {
                    angle += (90 - angle) * 2;
                }

                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else if (transform.position.y >= 8.0f)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), Mathf.Clamp(transform.position.y, -5.0f, 10.0f), 0.0f);
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