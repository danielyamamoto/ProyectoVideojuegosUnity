using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTerny : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
		switch (collision.gameObject.tag) {
            case "TernyALaObra": SceneManager.LoadScene("PreObra"); break;
            case "TernyBusca": SceneManager.LoadScene("PreBusca"); break;
            case "TernyCasa": SceneManager.LoadScene("CasaTernySc"); break;
            case "CasaCampo": SceneManager.LoadScene("CasaDeCampoSc"); break;
            case "TernyPlaza": SceneManager.LoadScene("TernyPlazaSc"); break;
            case "TernyStation": SceneManager.LoadScene("TernyStationSc"); break;
            case "Biblio": SceneManager.LoadScene("BiblioSc"); break;
            default: break;
		}
    }
}