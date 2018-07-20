
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
    #region Variables (public)


    public Arme m_pArme = null;

    public Animator m_pAnimator = null;

    public int m_iHp = 100;

    public float m_fVitesse = 10.0f;



    #endregion

    #region Variables (private)



    #endregion

    abstract protected void MovePersonnage();

    /// <summary>
    /// lance l attaque de mon arme si elle existe
    /// </summary>
    virtual protected void Attaquer()
    {
        m_pArme?.Attaquer();
    }
}
