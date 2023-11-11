using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{   
    [SerializeField] RawImage _backgroundImage;
    Vector2 vector2;

    void Update()
    {
        MoveBackground(0.1f, 0.1f); 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void MoveBackground(float xSpeed, float ySpeed)
    {
        vector2 += new Vector2(xSpeed, ySpeed) * Time.deltaTime;
        _backgroundImage.uvRect = new Rect(vector2, Vector2.one);         
    }
}
