
using UnityEngine;

public class CameraPerso : MonoBehaviour
{
    #region Variables (public)

    public float m_FDistanceDeSuivi = 0.0f;
    public float m_fVitesseDeRotation = 0.0f;                                                                

    #endregion

    #region Variables (private)

    public PersonnageJoueur m_pTarget = null;
    public Transform m_pCameraTransform = null;


    #endregion

    private void LateUpdate()
    {
        SuivrePersonnage();
        TournerCamera();
    }

    private void SuivrePersonnage()
    {
        Vector3 tnouvellePositionPoint = m_pTarget.transform.position + Vector3.up;
        transform.position = tnouvellePositionPoint;

        Vector3 TnouvellePositionCamera = tnouvellePositionPoint - (m_pCameraTransform.forward * m_FDistanceDeSuivi);
        m_pCameraTransform.position = TnouvellePositionCamera;


    }

    private void TournerCamera()
    {



        float FMouseX = Input.GetAxis("Mouse X");
        if (FMouseX != 0.0f)
        {
            

            Vector3 tRotation = new Vector3(0.0f, FMouseX, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);
            transform.localEulerAngles += tRotation;
        }

        float FMouseY = Input.GetAxis("Mouse Y");
        if (FMouseY != 0.0f)
                
        {
            Vector3 tRotation = new Vector3(-FMouseY, 0.0f, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);

            Vector3 tRotationSiAjoutee = transform.eulerAngles + tRotation;
            if (tRotationSiAjoutee.x <= 55.0f && tRotationSiAjoutee.x >= 0.0f)
                transform.eulerAngles = tRotationSiAjoutee;








        }

    }
}

