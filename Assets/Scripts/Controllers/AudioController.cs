using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            if (!musicSource.gameObject.activeInHierarchy)
                musicSource.gameObject.SetActive(true);

            if (!musicSource.enabled)
                musicSource.enabled = true;

            musicSource.clip = clip;
            musicSource.Play();
        }
    }

}