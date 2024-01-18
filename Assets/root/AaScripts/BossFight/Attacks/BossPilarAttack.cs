using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossPilarAttack : MonoBehaviour
{
    [SerializeField] Animator bodyAnimator;

    private void Awake()
    {
        
    }
    /*
     
    -desaparece boss,
    -aparece atras,
    -inicia animacion ataque,
    -animacion ataque se encarga de llamar a los metodos:
    
    moveBoss

    , y al terminar llama al metodo get random attack
    
    */


    public void Attack()
    {
        bodyAnimator.SetTrigger("PilarAttack");
    }
}
