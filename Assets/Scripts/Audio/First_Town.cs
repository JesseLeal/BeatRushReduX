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
        Game.Instance.SetLaserIntensity(0.6f);
        Game.Instance.SetBallIntensity(45f);
        Game.Instance.SetShipIntensity(45f);
        yield return new WaitForSeconds(45f);
        Debug.Log("MedPhaseOne");
        StartCoroutine("MedPhaseOne");
    }

    IEnumerator MedPhaseOne()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_1");
        Game.Instance.SetLaserIntensity(45.970f);
        Game.Instance.SetBallIntensity(0.6f);
        Game.Instance.SetShipIntensity(45.970f);
        yield return new WaitForSeconds(45.970f);
        Debug.Log("MedPhaseTwo");
        StartCoroutine("MedPhaseTwo");
    }

    IEnumerator MedPhaseTwo()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_2");
        Game.Instance.SetLaserIntensity(59.652f);
        Game.Instance.SetBallIntensity(59.652f);
        Game.Instance.SetShipIntensity(0.6f);
        yield return new WaitForSeconds(59.652f);
        Debug.Log("MedPhaseThree");
        StartCoroutine("MedPhaseThree");
    }


    IEnumerator MedPhaseThree()
    {
        AkSoundEngine.SetState("Town_State", "Med_Phase_3");
        Game.Instance.SetLaserIntensity(0.7f);
        Game.Instance.SetBallIntensity(0.7f);
        Game.Instance.SetShipIntensity(0.7f);
        yield return new WaitForSeconds(41.893f);
        Debug.Log("Final");
        StartCoroutine("Final");
    }

    IEnumerator Final()
    {
        AkSoundEngine.SetState("Town_State", "Finish");
        Game.Instance.SetLaserIntensity(2f);
        Game.Instance.SetBallIntensity(2f);
        Game.Instance.SetShipIntensity(2f);
        yield return new WaitForSeconds(27f);
        Game.Instance.GameEnd(1);
    }

}
