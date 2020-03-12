using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : Singleton<Game>
{
    [SerializeField] GameObject m_laserEnemy = null;
    [SerializeField] GameObject m_ballEnemy = null;
    [SerializeField] GameObject m_shipEnemy = null;

    [SerializeField] TextMeshProUGUI m_scoreText = null;
    [SerializeField] TextMeshProUGUI m_multText = null;
    [SerializeField] GameObject m_DimPanel = null;

    [SerializeField] PlayerController m_player = null;
    [SerializeField] float m_laserIntensity = 1.0f;
    [SerializeField] float m_ballIntensity = 1.0f;
    [SerializeField] float m_shipIntensity = 1.0f;

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

        AudioListener.volume = PlayerPrefs.GetInt("MusicVolume", 100) / 100.0f;

        //temp code, just spawning enemies every now and then
        StartCoroutine(LaserSpawnRoutine());
        StartCoroutine(BallSpawnRoutine());
        StartCoroutine(ShipSpawnRoutine());
    }

    void Update()
    {
        m_streakTime += Time.deltaTime;
        m_scoremult = m_scoreMultipliers[Mathf.Clamp((int)Mathf.Floor(m_streakTime / 3.0f), 0, m_scoreMultipliers.Length - 1)];

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
        yield return new WaitForSeconds(m_laserIntensity);

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

            yield return new WaitForSeconds(m_laserIntensity);
        }
    }

    private IEnumerator BallSpawnRoutine()
    {
        yield return new WaitForSeconds(m_ballIntensity);

        float x_coord = 0.0f;
        Vector3 pos = new Vector3();
        
        while (true)
        {
            x_coord = Random.Range(-8.0f, 8.0f);
            pos = new Vector3(x_coord, 7.0f, 0.0f);

            Instantiate(m_ballEnemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(m_ballIntensity);
        }
    }

    private IEnumerator ShipSpawnRoutine()
    {
        yield return new WaitForSeconds(m_shipIntensity);

        float x_coord = 0.0f;
        Vector3 pos = new Vector3();

        while (true)
        {
            x_coord = Random.Range(-8.0f, 8.0f);
            pos = new Vector3(x_coord, 7.0f, 0.0f);

            Instantiate(m_shipEnemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(m_shipIntensity);
        }
    }

    public void SetLaserIntensity(float newIntensity)
    {
        m_laserIntensity = newIntensity;
    }

    public void SetBallIntensity(float newIntensity)
    {
        m_ballIntensity = newIntensity;
    }

    public void SetShipIntensity(float newIntensity)
    {
        m_shipIntensity = newIntensity;
    }

    public void GameEnd(int levelIndex)
    {
        StopAllCoroutines();

        StartCoroutine(GameEndRoutine(levelIndex));
    }

    private IEnumerator GameEndRoutine(int levelIndex)
    {
        yield return new WaitForSeconds(2.0f);
        m_canScore = false;

        if (m_score > PlayerPrefs.GetInt("HighScore" + levelIndex))
        {
            PlayerPrefs.SetInt("HighScore" + levelIndex, m_score);
        }

        m_DimPanel.SetActive(true);
        Image panelSprite = m_DimPanel.GetComponent<Image>();
        Color newColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        for (int i = 0; i < 180; i++)
        {
            newColor.a += 0.006f;
            panelSprite.color = newColor;
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("MainMenu");
    }
}