using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Ennemi qui grossi ou raptisse lorsqu'il est touch� par un projectile
/// </summary>
[RequireComponent(typeof(Animator))]
public class Ennemi : MonoBehaviour
{
    /// <summary>
    /// Appelle l'agent qui permet aux ennemis de se d�placer automatiquement
    /// </summary>
    private NavMeshAgent ennemisAgent;

    /// <summary>
    /// Le joueur auquel l'ennemi va se d�placer
    /// </summary>
    private GameObject joueur;

    /// <summary>
    /// Vitesse de l'ennemi
    /// </summary>
    private float vitesse = 0.6f;

    /// <summary>
    /// Vie de l'ennemi
    /// </summary>
    private int vie;

    void Start()
    {
        ennemisAgent = GetComponent<NavMeshAgent>();

        joueur = GameObject.FindGameObjectWithTag("Player");

        ennemisAgent.speed = vitesse;
        vie = 3;
    }

    void Update()
    {
        ennemisAgent.SetDestination(joueur.transform.position);
    }

    /// <summary>
    /// D�truit le projectile et joue l'animation de l'ennemi
    /// </summary>
    /// <param name="collision">Param�tre de collision</param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Projectile")
        {
            vie--;

            if (vie <=0)
            {
                Destroy(gameObject);
            }
            else if(vie ==1)
            {
                GetComponent<Animator>().SetBool("Touche", false);
            }
            else if(vie ==2)
            {
                GetComponent<Animator>().SetBool("Touche", true);
            }

            Destroy(collision.gameObject);
        }        
    }
}