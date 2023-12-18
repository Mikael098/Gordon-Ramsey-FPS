using System.Collections;
using UnityEngine;

public class GenerateurEnnemis : MonoBehaviour
{
    [SerializeField, Tooltip("Ennemi � g�n�rer")]
    private GameObject ennemi;

    /// <summary>
    /// D�claration d'une coroutine qui permet de g�n�rer les obstacles
    /// </summary>
    private Coroutine coroutine;

    /// <summary>
    /// Vitesse de g�n�ration des ennemis
    /// </summary>
    private float vitesseGenerationEnnemi;

    void Start()
    {
        vitesseGenerationEnnemi= 4f;

        DemarrerCoroutine();
    }

    /// <summary>
    /// Permet de commencer la coroutine qui va permettre de g�n�rer les obstacles
    /// </summary>
    public void DemarrerCoroutine()
    {
        coroutine = StartCoroutine("GenererEnnemiCoroutine");
    }

    /// <summary>
    /// Permet de finir la coroutine
    /// </summary>>
    public void ArreterCoroutine()
    {
        StopCoroutine(coroutine);
    }

    /// <summary>
    /// Permet de r�cup�rer la valeur du glisseur pour pouvoir mettre � jour la vitesse de g�n�ration des ennemis
    /// </summary>
    /// <param name="valeur">Valeur du glisseur qui d�finie la vitesse de g�n�ration des ennemis</param>
    public void RecupererVitesseGenerationGlisseur(float valeur)
    {
        vitesseGenerationEnnemi= valeur;
    }

    /// <summary>
    /// Permet de g�n�rer un ennemi selon la valeur r�cup�rer dans le glisseur et de faire jouer un son
    /// </summary>
    /// <returns>retourne un d�lai de deux secondes</returns>
    private IEnumerator GenererEnnemiCoroutine()
    {
        while (true)
        {
            GameObject nouveauEnnemi = Instantiate(ennemi, transform);
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            yield return new WaitForSeconds(vitesseGenerationEnnemi);
        }
    }
}