using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : Singleton<Game>
{
    [SerializeField] GameObject m_laserEnemy = null;
    [SerializeField] GameObject m_ballEnemy = null;
    [SerializeField] GameObject m_shipEnemy = null;

    [SerializeField] TextMeshProUGUI m_scoreText = null;
    [SerializeField] TextMeshProUGUI m_multText = null;

    [SerializeField] PlayerController m_player = null;
    [SerializeField] float m_intensity = 1.5f;

    private int m_score = 0;
    private int m_scoremult = 1;
    private bool m_canScore = true;
    private bool m_scoreIncrease = true;
    private float m_streakTime;
    private int[] m_scoreMultipliers = new int[] { 1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 30, 50, 100 };

    void Start()
    {
        if (m_player == null)
        {
            m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        //temp code, just spawning enemies every now and then
        StartCoroutine(LaserSpawnRoutine());
        StartCoroutine(BallSpawnRoutine());
        StartCoroutine(ShipSpawnRoutine());
    }

    void Update()
    {
        m_streakTime += Time.deltaTime;
        m_scoremult = m_scoreMultipliers[Mathf.Clamp((int)Mathf.Floor(m_streakTime / 5.0f), 0, m_scoreMultipliers.Length - 1)];

        if (m_canScore)
        {
            m_scoreIncrease = !m_scoreIncrease;
            if (m_scoreIncrease)
            {
                m_score += m_scoremult;
                m_scoreText.text = "Score: " + m_score.ToString("D8");
                m_multText.text = "Multiplier: X" + m_scoremult;
            }
        }
    }

    public void HitPlayer(int penalty)
    {
        StartCoroutine(HitRoutine(penalty));
    }

    private IEnumerator HitRoutine(int penalty)
    {
        m_canScore = false;
        m_score -= penalty;
        m_score = Mathf.Clamp(m_score, 0, int.MaxValue);
        m_streakTime = 0.0f;
        m_scoreText.text = "Score: " + m_score.ToString("D8");
        m_multText.text = "Multiplier: X0";
        m_player.Hit();

        yield return new WaitForSeconds(2.0f);

        m_canScore = true;
    }

    private IEnumerator LaserSpawnRoutine()
    {
        float x_coord = 0.0f;
        int z_rot = 0;
        Vector3 pos = new Vector3();
        Quaternion rot = new Quaternion();

        while (true)
        {
            x_coord = Random.Range(-8.0f, 8.0f);
            z_rot = Random.Range(-6, 7) * 5;
            pos = new Vector3(x_coord, 7.0f, 0.0f);
            rot = Quaternion.AngleAxis(z_rot, Vector3.forward);

            Instantiate(m_laserEnemy, pos, rot);

            //if (i % 10 == 0)
            //{
            //    m_intensity -= 0.1f;
            //}

            yield return new WaitForSeconds(m_intensity);
        }
    }

    private IEnumerator BallSpawnRoutine()
    {
        float x_coord = 0.0f;
        Vector3 pos = new Vector3();
        
        while (true)
        {
            x_coord = Random.Range(-8.0f, 8.0f);
            pos = new Vector3(x_coord, 7.0f, 0.0f);

            Instantiate(m_ballEnemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(m_intensity * 1.1f);
        }
    }

    private IEnumerator ShipSpawnRoutine()
    {
        float x_coord = 0.0f;
        Vector3 pos = new Vector3();

        while (true)
        {
            x_coord = Random.Range(-8.0f, 8.0f);
            pos = new Vector3(x_coord, 7.0f, 0.0f);

            Instantiate(m_shipEnemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(m_intensity * 4.0f);
        }
    }

    public void SetIntensity(float newIntensity)
    {
        m_intensity = newIntensity;
    }
}