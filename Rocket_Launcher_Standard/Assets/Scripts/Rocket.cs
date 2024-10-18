using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField]
    private float fuel = 100f;
    Rigidbody2D RocketRigidbody2D;
     protected RectTransform FilledTransform;
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    [SerializeField]  TextMeshProUGUI currentScoreTxt;
    [SerializeField]  TextMeshProUGUI highScoreTxt;
     float currentScore;
     float highScore;
     float fillamount;

    private RocketDashboard rocketDashboard;
    private RocketEnergySystem rocketEnergySystem;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        RocketRigidbody2D = GetComponent<Rigidbody2D>();
        FilledTransform = GameObject.Find("Filled").GetComponent<RectTransform>();
        fillamount += fuel;
    }
    public float Fuel // public 프로퍼티 추가
    {
        get { return fuel; }
        set { fuel = value; }
    }
    public float CurrentScore // public 프로퍼티 추가
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
    public float HighScore // public 프로퍼티 추가
    {
        get { return highScore; }
        set { highScore = value; }
    }
    public float FillAmount
    {
        get { return fillamount; }
        set { fillamount = value; }
    }
    public RectTransform FilledTransformProperty
    {
        get { return FilledTransform; }
    }
    public TextMeshProUGUI CurrentScoreTxt
    {
        get { return currentScoreTxt; }
    }
    public TextMeshProUGUI HighScoreTxt
    {
        get { return highScoreTxt; }
    }
    void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fillamount >= FUELPERSHOOT)
        {
            Vector2 rocketForce = new Vector2(0f, SPEED);
            RocketRigidbody2D.AddForce(rocketForce, ForceMode2D.Impulse);
            fillamount -= FUELPERSHOOT;
        }
    }


    void ReStartRocket()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}
