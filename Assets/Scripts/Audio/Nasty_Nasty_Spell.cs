using System.Collections;
using UnityEngine;

public class Nasty_Nasty_Spell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");
        AkSoundEngine.PostEvent("Nasty_Nasty_Spell", gameObject);
    }

    IEnumerator Intro()
    {
        AkSoundEngine.SetState("Nasty_State", "Intro");
        yield return new WaitForSeconds(29f);
        Debug.Log("MedPhaseOne");
        StartCoroutine("MedPhaseOne");
    }

    IEnumerator MedPhaseOne()
    {
        AkSoundEngine.SetState("Nasty_State", "Med_Phase_1");
        yield return new WaitForSeconds(31.2f);
        Debug.Log("IntensePhaseOne");
        StartCoroutine("IntensePhaseOne");
    }

    IEnumerator IntensePhaseOne()
    {
        AkSoundEngine.SetState("Nasty_State", "Intense_Phase_1");
        yield return new WaitForSeconds(31.3f);
        Debug.Log("MedPhaseTwo");
        StartCoroutine("MedPhaseTwo");
    }

    IEnumerator MedPhaseTwo()
    {
        AkSoundEngine.SetState("Nasty_State", "Med_Phase_2");
        yield return new WaitForSeconds(21.8f);
        Debug.Log("IntensePhaseTwo");
        StartCoroutine("IntensePhaseTwo");
    }

    IEnumerator IntensePhaseTwo()
    {
        AkSoundEngine.SetState("Nasty_State", "Intense_Phase_2");
        yield return new WaitForSeconds(28.533f);
        Debug.Log("RestPhaseOne");
        StartCoroutine("RestPhaseOne");
    }
    IEnumerator RestPhaseOne()
    {
        AkSoundEngine.SetState("Nasty_State", "Rest_Phase_1");
        yield return new WaitForSeconds(29.462f);
        Debug.Log("MedPhaseThree");
        StartCoroutine("MedPhaseThree");
    }

    IEnumerator MedPhaseThree()
    {
        AkSoundEngine.SetState("Nasty_State", "Med_Phase_3");
        yield return new WaitForSeconds(39.656f);
        Debug.Log("IntensePhaseThree");
        StartCoroutine("IntensePhaseThree");
    }

    IEnumerator IntensePhaseThree()
    {
        AkSoundEngine.SetState("Nasty_State", "Intense_Phase_3");
        yield return new WaitForSeconds(32.19f);
        Debug.Log("Finale");
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        AkSoundEngine.SetState("Nasty_State", "Finish");
        yield return new WaitForSeconds(0f);
    }

}
