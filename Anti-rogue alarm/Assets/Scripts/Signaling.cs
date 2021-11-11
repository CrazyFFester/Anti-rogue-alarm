using System.Collections;
using UnityEngine;

<<<<<<< HEAD
[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    private AudioSource _alarmSound;
    private bool _rogueInside;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>(); 
=======
public class Signaling : MonoBehaviour
{
    private AudioSource alarmSound;
    private bool rogueInside = false;

    private void Awake()
    {
        alarmSound = GetComponent<AudioSource>();   
>>>>>>> 32f1990e49e7f85095a30e1a78d774f9f94d52cf
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
<<<<<<< HEAD
            if (!_rogueInside)
            {
                StopCoroutine(ChangeSound(0f, 0.05f));
                StartCoroutine(ChangeSound(1f, 0.025f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _rogueInside = !_rogueInside;
            if (!_rogueInside)
            {
                StopCoroutine(ChangeSound(1f, 0.025f));
                StartCoroutine(ChangeSound(0f, 0.05f));
            }
        }
    }

    private IEnumerator ChangeSound(float targetVolume, float scaleDivision)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        if (_alarmSound.volume < targetVolume)
        {
            for (float i = _alarmSound.volume; i < targetVolume;)
            {
                i += scaleDivision;
                _alarmSound.volume = i;
                yield return waitForSeconds;
            }
        }
        else if (_alarmSound.volume > targetVolume)
        {
            for (float i = _alarmSound.volume; i > targetVolume;)
            {
                i -= scaleDivision;
                _alarmSound.volume = i;
                yield return waitForSeconds;
            }
=======
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
>>>>>>> 32f1990e49e7f85095a30e1a78d774f9f94d52cf
        }
    }
}