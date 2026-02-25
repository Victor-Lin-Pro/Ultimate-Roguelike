using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    [Header("Paramètres de flottaison")]
    [SerializeField] private float floatHeight = 0.5f;     // Hauteur du mouvement
    [SerializeField] private float floatSpeed = 2f;        // Vitesse du mouvement
    [SerializeField] private float rotationSpeed = 50f;    // Vitesse de rotation (optionnel)

    private Vector3 startPosition;
    private float randomOffset; // Pour que chaque item flotte différemment

    void Start()
    {
        // Sauvegarder la position de départ
        startPosition = transform.position;

        // Donner un offset aléatoire pour que les items ne flottent pas tous en même temps
        randomOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        // Mouvement de haut en bas avec une onde sinusoïdale
        // Mathf.Sin donne une valeur entre -1 et 1 qu'on multiplie par la hauteur
        float newY = startPosition.y + Mathf.Sin((Time.time + randomOffset) * floatSpeed) * floatHeight;

        // Appliquer la nouvelle position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Optionnel : faire tourner l'objet
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    // Pour voir la position de départ dans l'éditeur
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            startPosition = transform.position;
        }

        // Dessiner la zone de flottaison
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startPosition + Vector3.up * floatHeight, startPosition + Vector3.down * floatHeight);
    }
}