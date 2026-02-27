using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuCanva;

    public float playerHPValue;
    public float playerMaxHPValue;
    public string playerName;

    private PlayerStats ps;

    private void Awake()
    {
        ps = GameManager.Get.playerStats;
    }

    private void Start()
    {
        UpdateValue();
        menuCanva.SetActive(false);
    }

    private void Update()
    {
        UpdateValue();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanva.SetActive(!menuCanva.activeSelf);
            if (menuCanva.activeSelf)
            {
                Time.timeScale = 0f;
                GameManager.Get.canControl = false;
            }
            else
            {
                Time.timeScale = 1f;
                GameManager.Get.canControl = true;
            }
        }
    }

    private void UpdateValue()
    {
        playerHPValue = ps.PlayerLifeHeart();
        playerMaxHPValue = ps.PlayerMaxHeart();
    }
}
