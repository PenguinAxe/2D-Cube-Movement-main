using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxhealth;
    int PlayerCurrenthealth;
    bool stop;
    public HudManagerScript HUD;
    public GameOver GameOver;
    // Start is called before the first frame update
    void Start()
    {
        stop=false;
        PlayerCurrenthealth = PlayerMaxhealth;
        HUD.updatehealthbar(PlayerCurrenthealth);
    }

    public void PlayerTakeDamage(int Playerdamage)
    {
        PlayerCurrenthealth -= Playerdamage;
        HUD.updatehealthbar(PlayerCurrenthealth);
        if (PlayerCurrenthealth <=0 )
        {
            Die();//die
        }
    }
    public void Die()
    {
        GameOver.GameOve();
    }
}
