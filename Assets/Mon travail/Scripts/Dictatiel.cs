using UnityEngine;

/// <summary>
/// Permet de changer l'Affichage du dictatiel
/// </summary>
[RequireComponent(typeof(Animator))]
public class Dictatiel : MonoBehaviour
{
    /// <summary>
    /// Permet d'afficher le dictatiel seulement si la case est coché
    /// </summary>
    /// <param name="valeur">Valeur de la case à cocher</param>
    public void AffichageDictatiel(bool valeur)
    {
        GetComponent<Animator>().SetBool("affichage", valeur);
    }
}
