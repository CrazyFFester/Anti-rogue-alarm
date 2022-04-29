using UnityEngine;

public class EntryDetecting : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _rogueInside;
    private Coroutine _volumeUp;
    private Coroutine _volumeDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            if (!_rogueInside)
            {
                _volumeUp = StartCoroutine(_signaling.ChangeSound(1f, 0.025f));
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
                _volumeDown = StartCoroutine(_signaling.ChangeSound(0f, 0.05f));
            }
        }
    }
}