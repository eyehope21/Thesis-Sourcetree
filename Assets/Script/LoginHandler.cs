using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using System.Threading.Tasks;
public class LoginHandler : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void LoginUser()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ToastManager.Instance.ShowToast("Enter both email and password.");
            return;
        }

        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password)
        .ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                ToastManager.Instance.ShowToast("Login failed: " + task.Exception?.Flatten().InnerExceptions[0].Message);
                return;
            }

            ToastManager.Instance.ShowToast("Login successful!");
            PlayerPrefs.SetInt("IsLoggedIn", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ARScene");
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}