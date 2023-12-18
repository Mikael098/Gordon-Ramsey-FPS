using UnityEngine;

/// <summary>
/// Permet de g�rer l'animation de l'arme du joueur (CroissantPOV)
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationCroissantPOV : MonoBehaviour
{
    //Ex�cute l'animation de rupture lorsque la limte de projectiles est atteinte
    public void AnimationRupture()
    {
        GetComponent<Animator>().SetBool("limiteAtteinte", true);
    }

    //Ex�cute l'animation d'attente
    public void AnimationAttente()
    {
        GetComponent<Animator>().SetBool("limiteAtteinte", false);
    }
}
