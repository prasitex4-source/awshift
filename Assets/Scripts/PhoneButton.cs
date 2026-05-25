using UnityEngine;

public class PhoneButton : MonoBehaviour, IPulsable
{
    [SerializeField] private string digit; // "1","2"... "CALL", "HANG"

    public void Press()
    {
        // Le dice al teléfono qué tecla se ha pulsado
        // PhoneButton no sabe qué hace ese dígito — eso es problema del PhoneObject
        PhoneObject.Instance.PressButton(digit);
    }
}