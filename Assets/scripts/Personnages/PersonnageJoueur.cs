
using UnityEngine;

public class PersonnageJoueur : Personnage 
{
    #region Variables (public)

    public Rigidbody m_pRigidbody = null;


    public float m_fVitesseDeSaut = 1.0f;
    #endregion

    #region Variables (private)



    #endregion

   

    private void Update()
    {
        MovePersonnage();
        Jump();
        Attaquer();
    }

    override protected void MovePersonnage()
    {
         float FHorizontal = Input.GetAxis("Horizontal");
         float FVertical = Input.GetAxis("Vertical");

        Vector3 tDirection = new Vector3(FHorizontal, 0.0f, FVertical);

        if (tDirection != Vector3.zero)         
        {

           tDirection = CameraPerso.Instance.transform.TransformDirection(tDirection);
            tDirection.y = 0.0f;

            if (tDirection.sqrMagnitude != 0.0f)
               tDirection.Normalize();
            
            else
                tDirection = transform.forward;


            Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime); // deplacement de 1 en profondeur
            m_pRigidbody.MovePosition(transform.position + tDeplacement);

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


    override protected void Attaquer()
    {
        if (Input.GetButton("Fire1"))
        {
          Vector3 tDirectionDattaque = Input.mousePosition;

            tDirectionDattaque.x /= Screen.width;
            tDirectionDattaque.y /= Screen.height;

            tDirectionDattaque -= new Vector3(0.5f, 0.5f, 0.0f); //on le prend par rapport au centre de l ecran (donc (x=0.5, y=0.5))

            tDirectionDattaque.z = tDirectionDattaque.y;
            tDirectionDattaque.y = 0.0f;

            tDirectionDattaque = CameraPerso.Instance.transform.TransformDirection(tDirectionDattaque);
            tDirectionDattaque.y = 0.0f;


            if(tDirectionDattaque != Vector3.zero)
            transform.forward = tDirectionDattaque.normalized;

            base.Attaquer();

        }
    }

}                                                               