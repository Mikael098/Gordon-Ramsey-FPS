using System.Collections;
using UnityEngine;

public class GenerateurEnnemis : MonoBehaviour
{
    [SerializeField, Tooltip("Ennemi à générer")]
    private GameObject ennemi;

    /// <summary>
    /// Déclaration d'une coroutine qui permet de générer les obstacles
    /// </summary>
    private Coroutine coroutine;

    /// <summary>
    /// Vitesse de génération des ennemis
    /// </summary>
    private float vitesseGenerationEnnemi;

    void Start()
    {
        vitesseGenerationEnnemi= 4f;

        DemarrerCoroutine();
    }

    /// <summary>
    /// Permet de commencer la coroutine qui va permettre de générer les obstacles
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
    /// Permet de récupérer la valeur du glisseur pour pouvoir mettre à jour la vitesse de génération des ennemis
    /// </summary>
    /// <param name="valeur">Valeur du glisseur qui définie la vitesse de génération des ennemis</param>
    public void RecupererVitesseGenerationGlisseur(float valeur)
    {
        vitesseGenerationEnnemi= valeur;
    }

    /// <summary>
    /// Permet de générer un ennemi selon la valeur récupérer dans le glisseur et de faire jouer un son
    /// </summary>
    /// <returns>retourne un délai de deux secondes</returns>
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