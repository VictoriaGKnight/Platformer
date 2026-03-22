using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    void PlayCoinSound(int newScore)
    {
        PlaySoundEffect(coinSound);
    }

    void PlayDamageSound(int newHealth)
    {
        PlaySoundEffect(damageSound);
    }

    void Start()
    {
        PlayMusic(backgroundMusic);
        SubscribeToGameManagerEvents();
    }

    void OnEnable()
    {
        SubscribeToGameManagerEvents();
    }

    void OnDisable()
    {
        UnsubscribeFromGameManagerEvents();
    }

    private void SubscribeToGameManagerEvents()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged -= PlayCoinSound;
            GameManager.Instance.onHealthChanged -= PlayDamageSound;

            GameManager.Instance.onScoreChanged += PlayCoinSound;
            GameManager.Instance.onHealthChanged += PlayDamageSound;
        }
    }

    private void UnsubscribeFromGameManagerEvents()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged -= PlayCoinSound;
            GameManager.Instance.onHealthChanged -= PlayDamageSound;
        }
    }
}