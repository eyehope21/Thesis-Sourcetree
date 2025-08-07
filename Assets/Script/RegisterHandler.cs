using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using System.Threading.Tasks;

public class RegisterHandler : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void RegisterUser()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ToastManager.Instance.ShowToast("Email and Password are required.");
            return;
        }

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email, password)
        .ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                ToastManager.Instance.ShowToast("Registration failed: " + task.Exception?.Flatten().InnerExceptions[0].Message);
                return;
            }

            ToastManager.Instance.ShowToast("Registration successful!");
            
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}