using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
class RocketDashboard : Rocket
{
    protected override void ScoreUpdate()
    {
        CurrentScore = this.gameObject.transform.position.y;
        ScoreUIUpdate(currentScoreTxt, CurrentScore);
        HighScoreDataUpdate();
        ScoreUIUpdate(HighScoreTxt, HighScore);
    }
    void ScoreUIUpdate(TextMeshProUGUI textUI, float score)
    {
        if (textUI == HighScoreTxt)
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
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

}