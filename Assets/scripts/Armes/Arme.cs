﻿
using UnityEngine;

abstract public class Arme : MonoBehaviour
{
    #region Variables (public)


    public Personnage m_pMaitre = null;

    public int m_iDegats = 10;
    public int m_iAttaquesParsecondes =  0;

    #endregion

    #region Variables (private)



    #endregion


    abstract public void Attaquer(); 


}
