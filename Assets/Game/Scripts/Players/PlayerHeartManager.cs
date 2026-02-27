using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartManager : MonoBehaviour
{
    public enum HeartType
    {
        FULL_LIFE_HEART = 0,
        HALF_LIFE_HEART = 1,
        EMPTY_LIFE_HEART = 2,
        HALF_ETERNAL_HEART = 3,
        FULL_COIN_HEART = 5
    }

    private PlayerStats ps;

    // Heart Count
    public List<Image> hearts = new List<Image>();
    // Heart Image
    public List<Sprite> heartImages = new List<Sprite>();
    /*
     * Sprite 0     Full Life Heart
     * Sprite 1     Half Life Heart
     * Sprite 2     Empty Life Heart
     * Sprite 3     Half Eternal Heart
     * Sprite 4     
     * Sprite 5     Full Coin Heart
     * Sprite 6     Empty Coin Heart
     * Sprite 7     Full Soul Heart
     * Sprite 8     Half Soul Heart
     * Sprite 9     Full Black Heart
     * Sprite 10    Halft Black Heart
     * Sprite 11    Gold Heart
     * Sprite 12    Half Coin Heart
     * Sprite 13    
     * Sprite 14    
     * Sprite 15    
     * Sprite 16    
     * Sprite 17    
     * Sprite 18    
     * Sprite 19    
     * Sprite 20    
     * Sprite 21    
     * Sprite 22    
     * Sprite 23    
     * Sprite 24    
     * Sprite 25    
     * Sprite 26    
     * Sprite 27    
     * Sprite 28    
     */

    private void Awake()
    {
        
    }

    private void Start()
    {
        ps = GameManager.Get.playerStats;
        InitHearts(ps.PlayerMaxHeart());
        UpdateHearts(ps.PlayerLifeHeart());
    }

    private void Update()
    {
        // Appeler cette méthode à chaque fois que les HP changent
        UpdateHearts(ps.PlayerLifeHeart());
    }

    public void InitHearts(float maxHearts)
    {
        // Désactiver tous les cœurs d'abord
        foreach (Image heart in hearts)
        {
            heart.gameObject.SetActive(false);
        }

        // Activer seulement le nombre de cœurs nécessaire selon le max
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < hearts.Count)
            {
                hearts[i].gameObject.SetActive(true);
            }
        }
    }

    public void UpdateHearts(float currentHealth)
    {
        float maxHearts = ps.PlayerMaxHeart();

        // Convertir les HP en nombre de cœurs (1 HP = 1 demi-cœur)
        int totalHalfHearts = Mathf.RoundToInt(currentHealth * 2); // 1 HP = 2 demi-cœurs? Non! 
                                                                   // Correction: 1 HP = 1 demi-cœur, donc currentHealth = nombre de demi-cœurs

        int fullHearts = Mathf.FloorToInt(currentHealth / 2); // Nombre de cœurs pleins
        bool hasHalfHeart = (currentHealth % 2 == 1); // Vérifie s'il reste un demi-cœur

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i >= maxHearts)
            {
                // Désactiver les cœurs au-delà du maximum
                hearts[i].gameObject.SetActive(false);
                continue;
            }

            hearts[i].gameObject.SetActive(true);

            if (i < fullHearts)
            {
                // Cœur plein
                hearts[i].sprite = heartImages[(int)HeartType.FULL_LIFE_HEART];
            }
            else if (i == fullHearts && hasHalfHeart)
            {
                // Demi-cœur
                hearts[i].sprite = heartImages[(int)HeartType.HALF_LIFE_HEART];
            }
            else
            {
                // Cœur vide
                hearts[i].sprite = heartImages[(int)HeartType.EMPTY_LIFE_HEART];
            }
        }
    }

    // Méthode utilitaire pour mettre à jour quand le max change
    public void OnMaxHeartsChanged(int newMaxHearts)
    {
        InitHearts(newMaxHearts);
        UpdateHearts(ps.PlayerLifeHeart());
    }
}
