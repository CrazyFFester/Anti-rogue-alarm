using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private AudioSource alarmSound;
    private bool rogueInside = false;

    private void Awake()
    {
        alarmSound = GetComponent<AudioSource>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            if (!rogueInside)
            {
                StopAllCoroutines();
                rogueInside = true;
                StartCoroutine(ChangeSound(1f, 0.025f));
            }

            else
            {
                StopAllCoroutines();
                rogueInside = false;
                StartCoroutine(ChangeSound(0f, -0.05f));
            }
        }
    }
     
    private IEnumerator ChangeSound(float maxVolume, float scaleDivision)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        for (float i = alarmSound.volume; i != maxVolume; i+= scaleDivision)
        {
            alarmSound.volume = i;
            yield return waitForSeconds;
        }
    }
}