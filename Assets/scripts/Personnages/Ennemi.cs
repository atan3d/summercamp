
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


 
    }




    protected override void Attaquer()
    {
     
    }

    protected override void MovePersonnage()
    {
        Vector3 tDestination = m_pCible.transform.position;

            RaycastHit tHit;

     if  ( Physics.Raycast(transform.position + Vector3.up,(tDestination - transform.position).normalized, out tHit, 300.0f, LayerMask.GetMask("personnage"), QueryTriggerInteraction.Collide));

        m_pNavMeshAgent.SetDestination(tHit.point - Vector3.up);
    }

    private void AnimeMarche()
    {
        m_pAnimator.SetBool("Bouge", m_pNavMeshAgent.velocity != Vector3.zero);
    }

}
