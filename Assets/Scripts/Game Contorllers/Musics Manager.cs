using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource MusicSource;
    public AudioSource PlayerSource;
    public AudioSource EffectsSource;
    public AudioSource EnemiesSource;

    [Header("UI Musics")]
    public AudioClip BG_Music;
    public AudioClip WinClip;
    public AudioClip LoseClip;
    public AudioClip Click_on_Buttons_Clip;
    [Header("Player Audio")]
    public AudioClip WalkClip;
    public AudioClip JumpClip;
    public AudioClip DamageClip;
    [Header("Items")]
    public AudioClip EatClip;
    [Header("Enemies")]
    public AudioClip Cast_Bullot_Clip;
    public AudioClip Cast_Rino_to_Wall;

    [SerializeField] private bool isLose_Music_Played;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //MusicSource = GetComponent<AudioSource>();
        //PlayerSource = GetComponent<AudioSource>();
        //EffectsSource = GetComponent<AudioSource>();
        //EnemiesSource = GetComponent<AudioSource>();

        isLose_Music_Played = true;

        if (BG_Music != null)
        {
            MusicSource.clip = BG_Music;
            MusicSource.loop = true;
            MusicSource.Play();
        }
    }

    // Player Audios
    public void Jump_Player()
    {
        PlayerSource.PlayOneShot(JumpClip, 0.7f);
    }
    public void Damage_Player()
    {
        PlayerSource.PlayOneShot(DamageClip, 0.45f);
    }
    
    //Items Audios
    public void Eat_Fruits()
    {
        EffectsSource.PlayOneShot(EatClip, 0.2f);
    }

    //Menu Audios
    public void Win_Music()
    {
        EffectsSource.PlayOneShot(WinClip, 0.1f);
        MusicSource.clip = null;
    }
    public void Lose_Music()
    {
        if (!EffectsSource.isPlaying && isLose_Music_Played)
        {
            EffectsSource.PlayOneShot(LoseClip, 0.6f);
            isLose_Music_Played = false;
        }
        MusicSource.clip = null;
    }

    public void Pause_BG_Music()
    {
        MusicSource.Pause();
    }
    public void UnPause_BG_Music()
    {
        MusicSource.UnPause();
    }
    public void Click_on_Buttons()
    {
        EffectsSource.PlayOneShot(Click_on_Buttons_Clip);
    }

    //Enemy Audios
    public void Cast_Bullot()
    {
        EnemiesSource.PlayOneShot(Cast_Bullot_Clip, 0.8f);
    }
    public void Cast_Rino_To_Wall()
    {
        EnemiesSource.PlayOneShot(Cast_Rino_to_Wall, 0.8f);
    }
}
