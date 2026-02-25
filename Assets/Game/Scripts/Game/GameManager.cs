using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManger;

    [Header("Player Character")]
    public PlayerCharacter playerCharacter;
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
        uiManger.playerHPValue = playerCharacter.GetPlayerHealth();
        uiManger.playerMaxHPValue = playerCharacter.GetPlayerMaxHealth();
    }
}
