
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitre : MonoBehaviour
{
    #region Variables (public)



    #endregion

    #region Variables (private)

    public string m_sNomDeLaScene = null;

    #endregion

    public void LancerJeu()
    {
        SceneManager.LoadScene(m_sNomDeLaScene);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

}
