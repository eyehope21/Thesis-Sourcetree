using TMPro;
using UnityEngine;

public class PlayerInfoDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;

    private void Start()
    {
        // Replace with dynamic values later
        string playerName = "EyeHope";
        int playerLevel = 10;

        nameText.text = $"Player: {playerName}";
        levelText.text = $"Level: {playerLevel}";
    }
}
