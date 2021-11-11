using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
<<<<<<< Updated upstream
  
public class Signaling : MonoBehaviour
{
    private AudioSource alarmSound;
    private bool rogueInside;

    private void Awake()
    {
        alarmSound = GetComponent<AudioSource>();   
=======

public class Signaling : MonoBehaviour
{
    private AudioSource _alarmSound;
    private bool _rogueInside;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
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
<<<<<<< Updated upstream
            
=======
>>>>>>> Stashed changes
        }
    }
}
