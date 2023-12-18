using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de changer de scène
/// </summary>
public class Recommencer : MonoBehaviour
{
    /// <summary>
    /// Permet de changer de scène selon l'id de la scène.
    /// Dans ce cas, de quitter le dictatiel
    /// Code inspiré de: https://www.youtube.com/watch?v=EMo-MaKkP9s
    /// </summary>
    /// <param name="sceneID">L'id de la scène qu'on souhaite aller</param>
    public void ChangerScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
