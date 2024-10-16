using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField]
    private float fuel = 100f;
    Rigidbody2D RocketRigidbody2D;

    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;
    float CurrentScore;
    float HighScore;


    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        RocketRigidbody2D = GetComponent<Rigidbody2D>();
    }


    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT)
        {
            Vector2 rocketForce = new Vector2(0f, SPEED);
            RocketRigidbody2D.AddForce(rocketForce, ForceMode2D.Impulse);
                fuel -= FUELPERSHOOT;
        }
    }


    public void ReStartRocket()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
    private void Update()
    {
        CurrentScore = this.gameObject.transform.position.y;
        ScoreUIUpdate(currentScoreTxt, CurrentScore);
        HighScoreDataUpdate();
        ScoreUIUpdate(HighScoreTxt, HighScore);
    }


    void ScoreUIUpdate(TextMeshProUGUI textUI,float score)
    {
       if(textUI == HighScoreTxt)
        {
            textUI.text = $"HIGH : {(int)score} M";
        }
        else
        {
        textUI.text = $"{(int)score} M";
        }
    }


    void HighScoreDataUpdate()
    {
        if(CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

}
