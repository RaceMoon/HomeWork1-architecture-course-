using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GeneralBall.BallBurst += PlaySound;
    }

    private void OnDisable()
    {
        GeneralBall.BallBurst -= PlaySound;
    }
    private void PlaySound(Transform transform)
    {
        _audioSource.PlayOneShot(_audioClip);
    }

}
