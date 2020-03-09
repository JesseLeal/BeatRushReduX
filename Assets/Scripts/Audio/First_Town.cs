using System.Collections;
using UnityEngine;

public class First_Town : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");
        AkSoundEngine.PostEvent("First_Town", gameObject);
    }

    IEnumerator Intro()
    {
        AkSoundEngine.SetState("Town_State", "Intro");
        yield return new WaitForSeconds(45f);
        Debug.Log("MedPhaseOne");
        StartCoroutine("MedPhaseOne");
    }

    IEnumerator MedPhaseOne()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_1");
        yield return new WaitForSeconds(45.970f);
        Debug.Log("MedPhaseTwo");
        StartCoroutine("MedPhaseTwo");
    }

    IEnumerator MedPhaseTwo()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_2");
        yield return new WaitForSeconds(59.652f);
        Debug.Log("MedPhaseThree");
        StartCoroutine("MedPhaseThree");
    }


    IEnumerator MedPhaseThree()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_3");
        yield return new WaitForSeconds(41.893f);
        Debug.Log("Final");
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        AkSoundEngine.SetState("Town_State", "Finish");
        yield return new WaitForSeconds(0f);
    }

}
