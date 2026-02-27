using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public bool canControl = true;

    public UIManager uiManger;

    [Header("Player Character")]
    public PlayerCharacter playerCharacter;
    [Header("Player Stats")]
    public PlayerStats playerStats;
    [Header("Player Heart Manager")]
    public PlayerHeartManager playerHeartManager;
    [Header("Player Controller")]
    public PlayerController playerController;
    [Header("Pool Manager")]
    public PoolManager poolManager;

    #region Static
    public static GameManager Get
    {
        get
        {
            return mInstance;
        }
    }
    private static GameManager mInstance;
    #endregion

    public void Awake()
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        if (mInstance == null)
            mInstance = this;
    }


    private void Start()
    {
        uiManger.playerName = playerCharacter.name;
        uiManger.playerHPValue = playerStats.PlayerLifeHeart();
        uiManger.playerMaxHPValue = playerStats.PlayerMaxHeart();
    }
}
