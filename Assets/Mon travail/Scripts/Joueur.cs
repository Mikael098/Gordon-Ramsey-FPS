using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Permet de gérer les actions possible du joueur
/// </summary>
[RequireComponent(typeof(Animator))]
public class Joueur : MonoBehaviour
{
    /// <summary>
    /// Permet d'appeler le Rigidbody
    /// </summary>
    private Rigidbody rigidbody;

    /// <summary>
    /// Défénie la vitesse de déplacement du joueur
    /// </summary>
    private float vitesse;

    /// <summary>
    /// Défénie la vitesse de rotation du joueur
    /// </summary>
    private float vitesseRotation;

    /// <summary>
    /// Vie du joueur
    /// </summary>
    private int vie;

    /// <summary>
    /// Temps de survie du joueur
    /// </summary>
    private float tempsSurvie;

    /// <summary>
    /// Nombre de projectile tiré
    /// </summary>
    private int nombreProjectile;

    /// <summary>
    /// Nombre de projectile présent
    /// </summary>
    private int maximumNombreProjectile;

    /// <summary>
    /// Event qui va permettre de démarrer la coroutine
    /// </summary>
    public UnityEvent demarrerAnimationRupture;

    /// <summary>
    /// Event qui permet de démarrer la coroutine
    /// </summary>
    public UnityEvent demarrerAnimationAttente;

    [SerializeField, Tooltip("Référence au script UI pour le temps de survie")]
    private UI uiTempsSurvie;

    [SerializeField, Tooltip("Référence au script UI pour la vie du joueur")]
    private UI uiVieJoueur;

    [SerializeField, Tooltip("Les projectiles que le joueur génère")]
    private GameObject projectile;


    void Start()
    {
        vitesse = 3f;
        vitesseRotation = 60f;
        vie = 3;
        tempsSurvie = 0f;
        maximumNombreProjectile= 10;

        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = vitesse  *transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = vitesse * -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = vitesse  * transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = vitesse *-transform.right;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down, vitesseRotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, vitesseRotation * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Démarre l'animation de rupture lorsque le maximum de munitions est atteintes
            if(nombreProjectile>=maximumNombreProjectile)
            {
                demarrerAnimationRupture.Invoke();
            }

            //Si le maximum de projectiles n'est pas atteinte, on génère un projectile
            else if(nombreProjectile<maximumNombreProjectile)
            {
                GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                Rigidbody rigidbody = newProjectile.GetComponent<Rigidbody>();

                rigidbody.velocity = transform.forward * 5f;

                nombreProjectile++;

                demarrerAnimationAttente.Invoke();

                StartCoroutine(DiminueNombreProjectile(newProjectile));
            }
        }

        tempsSurvie += Time.deltaTime;

        uiTempsSurvie.AjouterValeur(tempsSurvie);
        uiVieJoueur.AjouterValeur(vie);

        if(vie<=0)
        {
            SceneManager.LoadScene(1);
        }
    }

    /// <summary>
    /// Permet de récupérer la valeur du menu déroulant pour pouvoir changer la limite maximal de projectiles pouvant être instancier en même temps
    /// </summary>
    /// <param name="position">Position de la valeur dans le menu déroulant</param>
    public void RecupererLimiteProjectileMenuDeroulant(int position)
    {
        if(position==0)
        {
            maximumNombreProjectile = 5;
        }
        else if(position==1)
        {
            maximumNombreProjectile = 10;
        }
        else if(position ==2)
        {
            maximumNombreProjectile = 15;
        }
    }

    /// <summary>
    /// Coroutine pour diminuer le nombre de projectile et détruit le nombre de projectiles après 7 secondes
    /// </summary>
    /// <param name="newProjectile">Le nouveau projectile</param>
    private IEnumerator DiminueNombreProjectile(GameObject newProjectile)
    {
        yield return new WaitForSeconds(7f);

        Destroy(newProjectile);
        nombreProjectile--;
    }

    /// <summary>
    /// Détruit l'ennemi et enlève une vie au joueur lorsqu'une collision avec un ennemi est fait
    /// </summary>
    /// <param name="collision">Paramètre de collision</param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ennemi")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            Destroy(collision.gameObject);
            vie--;            
        }
    }
}