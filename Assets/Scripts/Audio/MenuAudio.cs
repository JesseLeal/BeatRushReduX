using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public AudioSource menuSong;

    // Update is called once per frame
    private void Start()
    {
        menuSong.volume = 0.0f;
    }
    void Update()
    {
        if(menuSong.volume <= 1f)
        {
            menuSong.volume += 0.002f;
        }
    }
}
