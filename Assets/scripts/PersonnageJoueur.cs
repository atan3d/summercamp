
using UnityEngine;

public class PersonnageJoueur : MonoBehaviour
{
    #region Variables (public)

    public Transform m_pCameraTransform = null;
    public Rigidbody m_pRigidbody = null;

   public int m_iHp = 100;

    public float m_fVitesse = 1000.0f;
    public float m_fVitesseDeSaut = 1.0f;
    #endregion

    #region Variables (private)



    #endregion


    private void Update()
    {
        MovePersonnage();
        Jump();
    }

    private void MovePersonnage()
    {
         float FHorizontal = Input.GetAxis("Horizontal");
         float FVertical = Input.GetAxis("Vertical");

        Vector3 tDirection = new Vector3(FHorizontal, 0.0f, FVertical);

        if (tDirection != Vector3.zero)

         
        {

            tDirection.Normalize();

           tDirection = m_pCameraTransform.TransformDirection(tDirection);

            Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime); // deplacement de 1 en profondeur
            m_pRigidbody.MovePosition(transform.position + tDeplacement);
         transform.position += tDeplacement;

            transform.forward = tDirection;

        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 tsaut = Vector3.up * (m_fVitesseDeSaut);
            m_pRigidbody.AddForce(tsaut, ForceMode.Impulse);
        }
    }

}                                                               