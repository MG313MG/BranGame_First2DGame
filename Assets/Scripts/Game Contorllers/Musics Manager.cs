using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerSounds {jump, damage, eat}
public enum UISounds {WinMusic,LoseMusic, Pause_BG_Music, UnPause_BG_Music}
public enum EnemiesSounds {Cast_Bullot,Cast_Rino_to_Wall }

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource MusicSource;
    public AudioSource PlayerSource;
    public AudioSource UISource;
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
    public AudioClip Cast_Rino_to_Wall_Clip;

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
    public void PlayPlayerSounds(PlayerSounds sound)
    {
        switch (sound)
        {
            case PlayerSounds.jump:
                PlayerSource.PlayOneShot(JumpClip, 0.7f);
                break;
            case PlayerSounds.damage:
                PlayerSource.PlayOneShot(DamageClip, 0.6f);
                break;
            case PlayerSounds.eat:
                PlayerSource.PlayOneShot(EatClip, 0.6f);
                break;
        }
    }

    //Menu Audios

    public void PlayUISounds(UISounds sounds)
    {
        switch (sounds)
        {
            case UISounds.WinMusic:
                UISource.PlayOneShot(WinClip, 0.1f);
                break;
            case UISounds.LoseMusic:
                if (!UISource.isPlaying && isLose_Music_Played)
                {
                    UISource.PlayOneShot(LoseClip, 0.6f);
                    isLose_Music_Played = false;
                }
                MusicSource.clip = null;
                break;
            case UISounds.Pause_BG_Music:
                MusicSource.Pause();
                break;
            case UISounds.UnPause_BG_Music:
                MusicSource.UnPause();
                break;
        }
    }
    public void Click_on_Buttons()
    {
        UISource.PlayOneShot(Click_on_Buttons_Clip);
    }

    //Enemy Audios

    public void PlayEnemiesSound(EnemiesSounds sounds)
    {
        switch (sounds)
        {
            case EnemiesSounds.Cast_Bullot:
                EnemiesSource.PlayOneShot(Cast_Bullot_Clip, 0.8f);
                break;
            case EnemiesSounds.Cast_Rino_to_Wall:
                EnemiesSource.PlayOneShot(Cast_Rino_to_Wall_Clip, 0.8f);
                break;
        }
    }
}
