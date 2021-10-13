using UnityEngine;

public class UpdateObjRecolectados : MonoBehaviour {
    public GameObject PSociedad, PFecha, PClock, PSemaforo, PSOE, PSaldo, PCaja, PPlantaTernium, PLiberar, PLentes;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "dSociedad" || collision.gameObject.tag == "dFecha" || collision.gameObject.tag == "clock" || 
            collision.gameObject.tag == "Semaforo" || collision.gameObject.tag == "dSOE" || collision.gameObject.tag == "Saldo" || 
            collision.gameObject.tag == "Caja" || collision.gameObject.tag == "PlantaTernium" || collision.gameObject.tag == "dLiberar" || 
            collision.gameObject.tag == "dLentes") {
            
            UIManagerTB.recolectados += 1;
            CountDown.isStoped = true;
            MovementInput.canMove = false;
            collision.collider.gameObject.SetActive(false);
            
            switch (collision.gameObject.tag) {
                case "dSociedad": PSociedad.SetActive(true); break;
                case "dFecha": PFecha.SetActive(true); break;
                case "clock": PClock.SetActive(true); break;
                case "Semaforo": PSemaforo.SetActive(true); break;
                case "dSOE": PSOE.SetActive(true); break;
                case "Saldo": PSaldo.SetActive(true); break;
                case "Caja": PCaja.SetActive(true); break;
                case "PlantaTernium": PPlantaTernium.SetActive(true); break;
                case "dLiberar": PLiberar.SetActive(true); break;
                case "dLentes": PLentes.SetActive(true); break;
            }
        }
    }
}
