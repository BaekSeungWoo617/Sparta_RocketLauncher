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
    [SerializeField] protected TextMeshProUGUI currentScoreTxt;
    [SerializeField] protected TextMeshProUGUI HighScoreTxt;
    protected float CurrentScore;
    protected float HighScore;
    [SerializeField] protected float fillamount;

    private RocketDashboard rocketDashboard;
    private RocketEnergySystem rocketEnergySystem;
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        RocketRigidbody2D = GetComponent<Rigidbody2D>();
        FilledTransform = GameObject.Find("Filled").GetComponent<RectTransform>();
        fillamount += fuel;
    }

    private void Update()
    {
        ScoreUpdate();
        FuelAdd(0.1f);
    }
    protected virtual void ScoreUpdate()
    {
        //Debug.Log("부모 호출");
    }
    protected virtual void FuelAdd(float amount)
    {
        //Debug.Log("부모 호출");
    }
    protected virtual void FilledImage()
    {
        //Debug.Log("FilledImage를 Rocket에서 호출");
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
        FilledImage();
    }


    void ReStartRocket()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}
