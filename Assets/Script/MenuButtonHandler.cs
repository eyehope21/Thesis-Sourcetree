using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void LoadStory()
    {
        SaveCurrentScene();
        SceneManager.LoadScene("Story mode"); // replace with actual scene name
    }


    //public void LoadBattle()
   // {
       // SaveCurrentScene();
       // SceneManager.LoadScene("Bat"); // replace with actual scene name
    //}


    public void LoadMenu()
    {
        SaveCurrentScene();
        SceneManager.LoadScene("Menu"); // replace with actual scene name
    }


    public void Back()
    {
        if (PlayerPrefs.HasKey("PreviousScene"))
        {
            string prevScene = PlayerPrefs.GetString("PreviousScene");
            SceneManager.LoadScene(prevScene);
        }
        else
        {
            Debug.LogWarning("No previous scene stored!");
        }
    }


    private void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("PreviousScene", currentScene);
    }
}
