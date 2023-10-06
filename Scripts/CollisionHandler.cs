using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;
    [SerializeField] float delay = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;
    int number;
    [SerializeField] public int sceneNumber = 1;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticle1;
    [SerializeField] ParticleSystem successParticle2;
    [SerializeField] GameObject LevelPassed;
    AudioSource audioSource;
    public AdsManager ads;

    bool isTransitioning = false;

    void Start()
    {
        GetHighScore(sceneNumber);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }

        switch (collision.gameObject.tag)
        {
            case "Coin":
                IncreaseScore(sceneNumber);
                break;
            default:
                audioSource.PlayOneShot(death);
                StartCrashSequence();
                break;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                IncreaseScore(sceneNumber);
                break;
            case "Finish":
                audioSource.PlayOneShot(success);
                StartSuccessSequence();
                break;
            default:
                break;

        }
    }

    void GetHighScore(int scene)
    {
        highScoreText.SetText("HighScore: " + PlayerPrefs.GetInt($"HighScore{scene}"));
    }

    void IncreaseScore(int scene)
    {
        score++;
        scoreText.SetText("Score: " + score.ToString());
        if (PlayerPrefs.GetInt($"HighScore{scene}") < score)
        {
            highScoreText.SetText("HighScore: " + score.ToString());
            PlayerPrefs.SetInt($"HighScore{scene}",score);
        }

    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        LevelPassed.SetActive(true);
        successParticle1.Play();
        successParticle2.Play();
        GetComponent<JetController>().enabled = false;
        ads.StartAds();
        Invoke("LoadMenu", 3);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        deathParticles.Play();
        GetComponent<JetController>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(3);
    }

    void ReloadLevel()
    {
        if (PlayerPrefs.GetInt("adsCounter") >= 0 && PlayerPrefs.GetInt("adsCounter") < 3)
        {
            PlayerPrefs.SetInt("adsCounter", PlayerPrefs.GetInt("adsCounter") + 1);
        }
        else if (PlayerPrefs.GetInt("adsCounter") == 3)
        {
            PlayerPrefs.SetInt("adsCounter", 0);
            ads.StartAds();
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
