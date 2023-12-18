using TMPro;
using UnityEngine;

/// <summary>
/// Permet de g�rer l'affichage de l'ui
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class UI : MonoBehaviour
{
    /// <summary>
    /// Texte de TexteMeshProUGUI
    /// </summary>
    private string texteUI;

    void Awake()
    {
        texteUI = GetComponent<TextMeshProUGUI>().text;
    }

    /// <summary>
    /// Permet d'ajouter une nouvelle valeur au texte
    /// F0 permet d'emp�cher les chiffres apr�s la virgule: 
    /// https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#FFormatString
    /// </summary>
    /// <param name="nouvelleValeur">La nouvelle valeur � afficher</param>
    public void AjouterValeur(float nouvelleValeur)
    {
        GetComponent<TextMeshProUGUI>().text = texteUI + " " + nouvelleValeur.ToString("F0");
    }
}
