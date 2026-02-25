using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public float playerHPValue;
    public float playerMaxHPValue;
    public string playerName;

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
        playerHPValue = GameManager.Get.playerCharacter.GetPlayerHealth();
        playerMaxHPValue = GameManager.Get.playerCharacter.GetPlayerMaxHealth();
        playerHPText.text = playerName + " : " + playerHPValue + " / " + playerMaxHPValue;
    }
}
