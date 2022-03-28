using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
  
public class Signaling : MonoBehaviour
{
    private AudioSource _alarmSound;
    private bool _rogueInside;
    private Coroutine _onTriggerEnter;
    private Coroutine _onTriggerExit;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            if (!_rogueInside)
            {
                _onTriggerEnter = StartCoroutine(ChangeSound(1f, 0.025f));
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
                StopCoroutine(_onTriggerEnter);
                _onTriggerExit = StartCoroutine(ChangeSound(0f, 0.05f));
            }
        }
    }

    private IEnumerator ChangeSound(float targetVolume, float scaleDivision)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        if (_alarmSound.volume < targetVolume)
        {
            while (_alarmSound.volume < targetVolume)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, scaleDivision);
                yield return waitForSeconds;
            }
        }
        else if (_alarmSound.volume > targetVolume)
        {
            while (_alarmSound.volume > targetVolume)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, scaleDivision);
                yield return waitForSeconds;
            }
        }
    }
}