using UnityEngine;

/// <summary>
/// Permet de gérer l'animation de l'arme du joueur (CroissantPOV)
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationCroissantPOV : MonoBehaviour
{
    //Exécute l'animation de rupture lorsque la limte de projectiles est atteinte
    public void AnimationRupture()
    {
        GetComponent<Animator>().SetBool("limiteAtteinte", true);
    }

    //Exécute l'animation d'attente
    public void AnimationAttente()
    {
        GetComponent<Animator>().SetBool("limiteAtteinte", false);
    }
}
