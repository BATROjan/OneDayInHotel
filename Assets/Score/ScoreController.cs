namespace Score
{
    public class ScoreController
    {
        private readonly ScoreView _scoreView;

        private int Score;
        
        public ScoreController(ScoreView scoreView)
        {
            _scoreView = scoreView;
            Score = 0;
        }

        public void UpdateScore()
        {
            _scoreView.ScoreText.text = Score.ToString();
        }

        public void ResetScore()
        {
            Score = 0;
            _scoreView.ScoreText.text = Score.ToString();
        }
    }
}