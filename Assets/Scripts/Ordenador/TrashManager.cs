using UnityEngine;

public class TrashManager : MonoBehaviour
{
    //faltaría hacer q los botones de atras no puedan pulsarse????
    //(q podríamos hacer que siga pudiendo navegar por varias pestañas a la vez,
    //pero personalmente haría que solo pueda estar solo en una pestaña para ahorrarnos trabajo :)!!
    public void OnCrossPress()
    {
        this.gameObject.SetActive(false);

    }
}
