using UnityEngine;

public class DetectingRogue : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _rogueInside;
    private Coroutine _volumeUp;
    private Coroutine _volumeDown;
    private int _maxVolume = 1;
    private int _minVolume = 0;
    private float _scaleDivisionForVolumeUp = 0.025f;
    private float _scaleDivisionForVolumeDown = 0.05f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            if (!_rogueInside)
            {
                _volumeUp = StartCoroutine(_signaling.ChangeSound(_maxVolume, _scaleDivisionForVolumeUp));
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
                StopCoroutine(_volumeUp);
                _volumeDown = StartCoroutine(_signaling.ChangeSound(_minVolume, _scaleDivisionForVolumeDown));
            }
        }
    }
}