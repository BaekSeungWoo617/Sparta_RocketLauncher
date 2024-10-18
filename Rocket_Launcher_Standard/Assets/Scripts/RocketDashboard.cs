using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
class RocketDashboard : MonoBehaviour
{
    [SerializeField] private Rocket rocket;
    private void Start()
    {
        TextMeshProUGUI currentScoreTxt = rocket.CurrentScoreTxt;
        TextMeshProUGUI highScoreTxt = rocket.HighScoreTxt;

    }
    private void Update()
    {
        ScoreUpdate();
    }
    void ScoreUpdate()
    {
        rocket.CurrentScore = this.gameObject.transform.position.y;
        ScoreUIUpdate(rocket.CurrentScoreTxt, rocket.CurrentScore);
        HighScoreDataUpdate();
        ScoreUIUpdate(rocket.HighScoreTxt, rocket.HighScore);
    }
    void ScoreUIUpdate(TextMeshProUGUI textUI, float score)
    {
        if (textUI == rocket.HighScoreTxt)
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
        if (rocket.CurrentScore > rocket.HighScore)
        {
            rocket.HighScore = rocket.CurrentScore;
        }
    }

}