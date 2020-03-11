using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUG_AND_KILL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");
        AkSoundEngine.PostEvent("Hug_and_kill", gameObject);
    }

    IEnumerator Intro()
    {
        AkSoundEngine.SetState("Hug_State", "Intro");
        Game.Instance.SetLaserIntensity(2f);
        Game.Instance.SetBallIntensity(2f);
        Game.Instance.SetShipIntensity(1f);
        yield return new WaitForSeconds(13.5f);
        Debug.Log("MedPhaseOne");
        StartCoroutine("MedPhaseOne");
    }

    IEnumerator MedPhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_1");
        Game.Instance.SetLaserIntensity(0.65f);
        Game.Instance.SetBallIntensity(0.5f);
        Game.Instance.SetShipIntensity(0.85f);
        yield return new WaitForSeconds(21.95f);
        Debug.Log("RestPhaseOne");
        StartCoroutine("RestPhaseOne");
    }

    IEnumerator RestPhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_1");
        Game.Instance.SetLaserIntensity(1f);
        Game.Instance.SetBallIntensity(1f);
        Game.Instance.SetShipIntensity(1f);
        yield return new WaitForSeconds(10f);
        Debug.Log("MedPhaseTwo");
        StartCoroutine("MedPhaseTwo");
    }

    IEnumerator MedPhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_2");
        Game.Instance.SetLaserIntensity(0.6f);
        Game.Instance.SetBallIntensity(0.8f);
        Game.Instance.SetShipIntensity(0.7f);
        yield return new WaitForSeconds(10.478f);
        Debug.Log("RestPhaseTwo");
        StartCoroutine("RestPhaseTwo");
    }

    IEnumerator RestPhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_2");
        Game.Instance.SetLaserIntensity(0.95f);
        Game.Instance.SetBallIntensity(1f);
        Game.Instance.SetShipIntensity(1.2f);
        yield return new WaitForSeconds(11.5f);
        Debug.Log("IntensePhaseOne");
        StartCoroutine("IntensePhaseOne");
    }

    IEnumerator IntensePhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_1");
        Game.Instance.SetLaserIntensity(0.2f);
        Game.Instance.SetBallIntensity(0.1f);
        Game.Instance.SetShipIntensity(0.3f);
        yield return new WaitForSeconds(22.0f);
        Debug.Log("RestPhaseThree");
        StartCoroutine("RestPhaseThree");
    }

    IEnumerator RestPhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_3");
        Game.Instance.SetLaserIntensity(1f);
        Game.Instance.SetBallIntensity(0.8f);
        Game.Instance.SetShipIntensity(1f);
        yield return new WaitForSeconds(9.08f);
        Debug.Log("MedPhaseThree");
        StartCoroutine("MedPhaseThree");
    }

    IEnumerator MedPhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_3");
        Game.Instance.SetLaserIntensity(0.9f);
        Game.Instance.SetBallIntensity(0.8f);
        Game.Instance.SetShipIntensity(0.7f);
        yield return new WaitForSeconds(22.85f);
        Debug.Log("RestPhaseFour");
        StartCoroutine("RestPhaseFour");
    }

    IEnumerator RestPhaseFour()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_4");
        Game.Instance.SetLaserIntensity(1.2f);
        Game.Instance.SetBallIntensity(1f);
        Game.Instance.SetShipIntensity(1f);
        yield return new WaitForSeconds(23.65f);
        Debug.Log("MedPhaseFour");
        StartCoroutine("MedPhaseFour");
    }

    IEnumerator MedPhaseFour()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_4");
        Game.Instance.SetLaserIntensity(0.9f);
        Game.Instance.SetBallIntensity(0.7f);
        Game.Instance.SetShipIntensity(0.9f);
        yield return new WaitForSeconds(13.339f);
        Debug.Log("IntensePhaseTwo");
        StartCoroutine("IntensePhaseTwo");
    }

    IEnumerator IntensePhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_2");
        Game.Instance.SetLaserIntensity(0.07f);
        Game.Instance.SetBallIntensity(45f);
        Game.Instance.SetShipIntensity(45f);
        yield return new WaitForSeconds(11.2f);
        Debug.Log("IntensePhaseThree");
        StartCoroutine("IntensePhaseThree");
    }
    IEnumerator IntensePhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_3");
        Game.Instance.SetLaserIntensity(0.02f);
        Game.Instance.SetBallIntensity(0.1f);
        Game.Instance.SetShipIntensity(0.1f);
        yield return new WaitForSeconds(32.417f);
        Debug.Log("Finale");
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        AkSoundEngine.SetState("Hug_State", "Finish");
        Game.Instance.SetLaserIntensity(1f);
        Game.Instance.SetBallIntensity(1f);
        Game.Instance.SetShipIntensity(1f);
        yield return new WaitForSeconds(18f);
        Game.Instance.GameEnd(3);
    }

}
