
using UnityEngine;

public class PersonnageJoueur : MonoBehaviour
{
    #region Variables (public)

   public int m_iHp = 100;

    public float m_fVitesse = 1000.0f;
    #endregion

    #region Variables (private)



    #endregion


    private void Update()
    {
        MovePersonnage();
    }

    private void MovePersonnage()
    {
         float FHorizontal = Input.GetAxis("Horizontal");
         float FVertical = Input.GetAxis("Vertical");

        Vector3 tDirection = new Vector3(FHorizontal, 0.0f, FVertical);

        if (tDirection != Vector3.zero)
        {

            tDirection.Normalize();

            Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime); // deplacement de 1 en profondeur
         transform.position += tDeplacement;

            transform.forward = tDirection;

        }
    }
}                                                               