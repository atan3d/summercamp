
using UnityEngine;

public class CameraPerso : MonoBehaviour
{
    #region Variables (public)

    public float m_FDirectionDeSuivi = 0.0f;

    #endregion

    #region Variables (private)

    public PersonnageJoueur m_pTarget = null;

    #endregion

    private void LateUpdate()
    {
        SuivrePersonnage();
    }

    private void SuivrePersonnage()
    {
        Vector3 tnouvellePosition = m_pTarget.transform.position + Vector3.up - transform.forward * m_FDirectionDeSuivi;
        transform.position = tnouvellePosition;
    }
}