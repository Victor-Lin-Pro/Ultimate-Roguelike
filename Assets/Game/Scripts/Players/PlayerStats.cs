using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /*
     * Red Heart
     * Half Red Heart
     * Soul Heart
     * Eternal Heart : Two Half can add 1 Max Heart
     * Double Heart
     * Black Heart : Like shield, but hit all enemies when break
     * Gold Heart : Like shield, but get coin when break
     * Half Soul Heart
     * Scared Heart
     * Blended Heart
     * Bone Heart
     * Rotten Heart
    */

    [SerializeField] private int playerStartHeart; // Half Heart Max

    [SerializeField] private float playerMaxHeart; // Half Heart Max
    [SerializeField] private float playerLifeHeart; // Full / Half / Double Heart
    [SerializeField] private float playerSoulHeart; // Full / Half Soul Heart (Shield)
    [SerializeField] private float playerEternalHeart;
    [SerializeField] private float playerBlackHeart;
    [SerializeField] private float playerGoldHeart;
    [SerializeField] private float playerBoneHeart;
    [SerializeField] private float playerRottenHeart;

    [SerializeField] private float playerLuck;
    [SerializeField] private float playerDevilLuck; // For Devil Room
    [SerializeField] private float playerAngelLuck; // For Angel Room

    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerFireRate;
    [SerializeField] private float playerDamage;
    [SerializeField] private float playerRange;
    [SerializeField] private float playerShotSpeed;

    // Getters
    public int PlayerStartHeart() => playerStartHeart;
    public float PlayerMaxHeart() => playerMaxHeart;
    public float PlayerLifeHeart() => playerLifeHeart;
    public float PlayerSoulHeart() => playerSoulHeart;
    public float PlayerEternalHeart() => playerEternalHeart;
    public float PlayerBlackHeart() => playerBlackHeart;
    public float PlayerGoldHeart() => playerGoldHeart;
    public float PlayerBoneHeart() => playerBoneHeart;
    public float PlayerRottenHeart() => playerRottenHeart;

    public float PlayerLuck() => playerLuck;
    public float PlayerDevilLuck() => playerDevilLuck;
    public float PlayerAngelLuck() => playerAngelLuck;

    public float PlayerSpeed() => playerSpeed;
    public float PlayerFireRate() => playerFireRate;
    public float PlayerDamage() => playerDamage;
    public float PlayerRange() => playerRange;
    public float PlayerShotSpeed() => playerShotSpeed;

    
    // Setters
    public void PlayerMaxHeart(float value) => playerMaxHeart = value;
    public void PlayerLifeHeart(float value) => playerLifeHeart = value >= 0 ? value : 0;
    public void PlayerSoulHeart(float value) => playerSoulHeart = value >= 0 ? value : 0;
    public void PlayerEternalHeart(float value) => playerEternalHeart = value >= 0 ? value : 0;
    public void PlayerBlackHeart(float value) => playerBlackHeart = value >= 0 ? value : 0;
    public void PlayerGoldHeart(float value) => playerGoldHeart = value >= 0 ? value : 0;
    public void PlayerBoneHeart(float value) => playerBoneHeart = value >= 0 ? value : 0;
    public void PlayerRottenHeart(float value) => playerRottenHeart = value >= 0 ? value : 0;

    public void PlayerLuck(float value) => playerLuck = value;
    public void PlayerDevilLuck(float value) => playerDevilLuck = value >= 0 ? value : 0;
    public void PlayerAngelLuck(float value) => playerAngelLuck = value >= 0 ? value : 0;

    public void PlayerSpeed(float value) => playerSpeed = value >= 0 ? value : 0;
    public void PlayerFireRate(float value) => playerFireRate = value >= 0 ? value : 0;
    public void PlayerDamage(float value) => playerDamage = value >= 0 ? value : 0;
    public void PlayerRange(float value) => playerRange = value >= 0 ? value : 0;
    public void PlayerShotSpeed(float value) => playerShotSpeed = value >= 0 ? value : 0;
}
