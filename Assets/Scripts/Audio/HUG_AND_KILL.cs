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
        yield return new WaitForSeconds(14.1f);
        Debug.Log("MedPhaseOne");
        StartCoroutine("MedPhaseOne");
    }

    IEnumerator MedPhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_1");
        yield return new WaitForSeconds(21.95f);
        Debug.Log("RestPhaseOne");
        StartCoroutine("RestPhaseOne");
    }

    IEnumerator RestPhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_1");
        yield return new WaitForSeconds(10f);
        Debug.Log("MedPhaseTwo");
        StartCoroutine("MedPhaseTwo");
    }

    IEnumerator MedPhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_2");
        yield return new WaitForSeconds(10.478f);
        Debug.Log("RestPhaseTwo");
        StartCoroutine("RestPhaseTwo");
    }

    IEnumerator RestPhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_2");
        yield return new WaitForSeconds(11f);
        Debug.Log("IntensePhaseOne");
        StartCoroutine("IntensePhaseOne");
    }

    IEnumerator IntensePhaseOne()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_1");
        yield return new WaitForSeconds(22.9f);
        Debug.Log("RestPhaseThree");
        StartCoroutine("RestPhaseThree");
    }

    IEnumerator RestPhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_3");
        yield return new WaitForSeconds(9.08f);
        Debug.Log("MedPhaseThree");
        StartCoroutine("MedPhaseThree");
    }

    IEnumerator MedPhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_3");
        yield return new WaitForSeconds(22.85f);
        Debug.Log("RestPhaseFour");
        StartCoroutine("RestPhaseFour");
    }

    IEnumerator RestPhaseFour()
    {
        AkSoundEngine.SetState("Hug_State", "Rest_Phase_4");
        yield return new WaitForSeconds(23.65f);
        Debug.Log("MedPhaseFour");
        StartCoroutine("MedPhaseFour");
    }

    IEnumerator MedPhaseFour()
    {
        AkSoundEngine.SetState("Hug_State", "Med_Phase_4");
        yield return new WaitForSeconds(12.339f);
        Debug.Log("IntensePhaseTwo");
        StartCoroutine("IntensePhaseTwo");
    }

    IEnumerator IntensePhaseTwo()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_2");
        yield return new WaitForSeconds(11.61f);
        Debug.Log("IntensePhaseThree");
        StartCoroutine("IntensePhaseThree");
    }
    IEnumerator IntensePhaseThree()
    {
        AkSoundEngine.SetState("Hug_State", "Intense_Phase_3");
        yield return new WaitForSeconds(32.417f);
        Debug.Log("Finale");
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        AkSoundEngine.SetState("Hug_State", "Finish");
        yield return new WaitForSeconds(0f);
    }

}
