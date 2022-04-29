using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
  
public class Signaling : MonoBehaviour
{
    private AudioSource _alarmSound;
    
    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    public IEnumerator ChangeSound(float targetVolume, float scaleDivision)
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