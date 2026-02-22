using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public int playerHP;

    private void Start()
    {
        UpdateValue();
    }

    private void Update()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        playerHP = GameManager.Get.playerCharacter.GetPlayerHealth();
        playerHPText.text = "Player HP : " + playerHP;
    }
}
