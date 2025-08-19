using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class MenuManager : MonoBehaviour
{
    private string previousScene;

    // Call this when opening Menu so we know where to go back
    public void SetPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }

    public void BackToPrevious()
    {
        // Load the saved scene name (default to ARScene if none found)
        string previousScene = PlayerPrefs.GetString("PreviousScene", "ARScene");
        SceneManager.LoadScene(previousScene);
    }

    public void Logout()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        SceneManager.LoadScene("Login"); // your login scene name
    }

    // Example stubs for other buttons
    public void OpenMail() => Debug.Log("Mail opened!");
    public void OpenQuest() => Debug.Log("Quest opened!");
    public void OpenInventory() => Debug.Log("Inventory opened!");
    public void OpenLeaderboard() => Debug.Log("Leaderboard opened!");
    public void OpenStore() => Debug.Log("Store opened!");
    public void OpenSettings() => Debug.Log("Settings opened!");
    public void OpenHistoryLog() => Debug.Log("History Log opened!");
}
