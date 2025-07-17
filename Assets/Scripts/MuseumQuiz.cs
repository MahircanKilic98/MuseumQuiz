using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuseumQuiz : MonoBehaviour
{
    [System.Serializable]
    public class QuizQuestion
    {
        public string question;
        public string answerA;
        public string answerB;
        public int correctAnswerIndex; // 0 = A, 1 = B
    }

    public QuizQuestion[] questions;
    private int currentQuestionIndex = -1;

    // UI-Elemente
    public Button startButton;
    public TMP_Text questionText;
    public Button answerButtonA;
    public Button answerButtonB;
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text resultText;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        startButton.onClick.AddListener(StartQuiz);
        answerButtonA.onClick.AddListener(() => CheckAnswer(0));
        answerButtonB.onClick.AddListener(() => CheckAnswer(1));
    }

    public void StartQuiz()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        startButton.gameObject.SetActive(false);
        resultText.text = "";
        currentQuestionIndex = 0;

        ShowQuestion();
    }

    public void ShowQuestion()
    {
        if (currentQuestionIndex >= questions.Length)
        {
            questionText.text = "";
            answerAText.text = "";
            answerBText.text = "";
            resultText.text = "Quiz beendet!";
            answerButtonA.gameObject.SetActive(false);
            answerButtonB.gameObject.SetActive(false);
            return;
        }

        var q = questions[currentQuestionIndex];
        questionText.text = q.question;
        answerAText.text = q.answerA;
        answerBText.text = q.answerB;

        // Reaktiviere Buttons für nächste Frage
        answerButtonA.interactable = true;
        answerButtonB.interactable = true;
    }

    public void CheckAnswer(int selectedIndex)
    {
        var q = questions[currentQuestionIndex];

        if (selectedIndex == q.correctAnswerIndex)
        {
            resultText.text = "Richtig!";
        }
        else
        {
            resultText.text = "Falsch!";
        }

        // Deaktiviere Buttons, damit man nicht doppelt klicken kann
        answerButtonA.interactable = false;
        answerButtonB.interactable = false;

        // Nächste Frage nach 2 Sekunden
        Invoke(nameof(NextQuestion), 2f);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        ShowQuestion();
    }
}