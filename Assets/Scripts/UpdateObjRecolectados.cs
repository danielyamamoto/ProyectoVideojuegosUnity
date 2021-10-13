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

            if (collision.gameObject.tag == "dSociedad") { PSociedad.SetActive(true); }

            if (collision.gameObject.tag == "dFecha") { PFecha.SetActive(true); }
            
            if (collision.gameObject.tag == "clock") { PClock.SetActive(true); }
            
            if (collision.gameObject.tag == "Semaforo") { PSemaforo.SetActive(true); }
            
            if (collision.gameObject.tag == "dSOE") { PSOE.SetActive(true); }
            
            if (collision.gameObject.tag == "Saldo") { PSaldo.SetActive(true); }
            
            if (collision.gameObject.tag == "Caja") { PCaja.SetActive(true); }
            
            if (collision.gameObject.tag == "PlantaTernium") { PPlantaTernium.SetActive(true); }
            
            if (collision.gameObject.tag == "dLiberar") { PLiberar.SetActive(true); }
            
            if (collision.gameObject.tag == "dLentes") { PLentes.SetActive(true); }
        }
    }
}
