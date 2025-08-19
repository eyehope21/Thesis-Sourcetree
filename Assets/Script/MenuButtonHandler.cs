using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void GoToMenu()
    {
        // Save the current scene name so we can return later
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        // Load the Menu scene
        SceneManager.LoadScene("Menu");
    }
}
