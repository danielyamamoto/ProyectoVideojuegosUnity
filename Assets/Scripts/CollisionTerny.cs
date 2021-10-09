using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTerny : MonoBehaviour
{
    // Este código va a ser draggeado a terny

    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "TernyALaObra") {
            SceneManager.LoadScene("PreObra");
        }

        if (collision.gameObject.tag == "TernyCasa") {
            SceneManager.LoadScene("CasaTernySc");
        }
        
        if (collision.gameObject.tag == "CasaCampo") {
            SceneManager.LoadScene("CasaDeCampoSc");
        }
        
        if (collision.gameObject.tag == "TernyPlaza") {
            SceneManager.LoadScene("TernyPlazaSc");
        }

        if (collision.gameObject.tag == "TernyStation") {
            SceneManager.LoadScene("TernyStationSc");
        }
        
        if (collision.gameObject.tag == "Biblio") {
            SceneManager.LoadScene("BiblioSc");
        }

        /*if (collision.gameObject.tag == "Memorama") {
            SceneManager.LoadScene("PreMemo");
        }*/

        if (collision.gameObject.tag == "TernyPide") {
            SceneManager.LoadScene("PreTernyPide");
        }

        if (collision.gameObject.tag == "SopaLetras") {
            SceneManager.LoadScene("PreSopa");
        }

        if (collision.gameObject.tag == "Acomoda") {
            SceneManager.LoadScene("PreAcomoda");
        }

        if (collision.gameObject.tag == "TernyBusca") {
            SceneManager.LoadScene("PreBusca");
        }
    }
}