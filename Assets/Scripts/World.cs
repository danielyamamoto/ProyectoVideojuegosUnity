using UnityEngine;

public class World : SceneController
{
    public Transform player;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        if (prevScene == "PreMemo")
        {
            player.position = new Vector3(-0.3f, 35f, -11.5f);
        }
        if (prevScene == "PreSopa")
        {
            player.position = new Vector3(0.15f, 35f, -15f);
        }
        if (prevScene == "PreTernyPide")
        {
            player.position = new Vector3(-2.4f, 35f, -12f);
        }
        if (prevScene == "PreAcomoda")
        {
            player.position = new Vector3(-3.1f, 35f, -15.8f);
        }
    }
}
