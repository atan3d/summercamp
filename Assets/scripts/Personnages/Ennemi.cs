
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : Personnage
{
    #region Variables (public)

    public Personnage m_pCible = null;

    public NavMeshAgent m_pNavMeshAgent = null;
  

    public float m_fDistanceDarret;


    #endregion

    #region Variables (private)




    #endregion




    private void LateUpdate()
    {
        if (m_pAnimator != null)
        AnimeMarche();
    }




    private void Start()
    {
        m_pNavMeshAgent.speed = m_fVitesse;
        m_pNavMeshAgent.stoppingDistance = m_fDistanceDarret;
    }



    private void Update()
    {
        if (m_pCible == null)
        
            return;
        MovePersonnage();

        //on est sur qu on a une cible

        if (m_pNavMeshAgent.velocity == Vector3.zero)
            Attaquer();


 
    }




    protected override void Attaquer()
    {
        transform.forward = (m_pCible.transform.position - transform.position).normalized;


        base.Attaquer();
    }

    protected override void MovePersonnage()
    {
        Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;

            RaycastHit tHit;

     if  ( Physics.Raycast(transform.position + Vector3.up, tDirection, out tHit, 300.0f, LayerMask.GetMask("personnage"), QueryTriggerInteraction.Collide));
        {
            Vector3 tDestination = tHit.point - Vector3.up - (m_pNavMeshAgent.radius * - tDirection/*notre largeur, vers l arriere */);
        m_pNavMeshAgent.SetDestination(tDestination);
        }
    }

    private void AnimeMarche()
    {

        m_pAnimator.SetBool("Bouge", m_pNavMeshAgent.velocity != Vector3.zero);
    }

}
