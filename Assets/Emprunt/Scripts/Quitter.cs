using UnityEngine;

/// <summary>
/// Bouton pour quitter la simulation
/// </summary>
public class Quitter : MonoBehaviour
{
    /// <summary>
    /// Force l'application � quitter
    /// </summary>
    public void QuitterApplication()
    {
        Application.Quit();
    }
}
