using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de changer de sc�ne
/// </summary>
public class Recommencer : MonoBehaviour
{
    /// <summary>
    /// Permet de changer de sc�ne selon l'id de la sc�ne.
    /// Dans ce cas, de quitter le dictatiel
    /// Code inspir� de: https://www.youtube.com/watch?v=EMo-MaKkP9s
    /// </summary>
    /// <param name="sceneID">L'id de la sc�ne qu'on souhaite aller</param>
    public void ChangerScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
