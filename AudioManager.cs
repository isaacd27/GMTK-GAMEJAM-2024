using System;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class audioManager : MonoBehaviour
{
    [SerializeField] static AudioSource SFXsource;

    #region Player Variables
    public static AudioClip playerJump;
    public static AudioClip playerMove;
    public static AudioClip getLarge;


    public static AudioClip getSmall;
    #endregion

    #region Environment Variables
    public static AudioClip gameOver;

    public static AudioClip Slimeball;

    public static AudioClip Break;
    public static AudioClip respawn;

    public static AudioClip Spong;
    #endregion



    void Start()
    {
        playerJump = Resources.Load<AudioClip>("Plop_sfx");

        Slimeball = Resources.Load<AudioClip>("Pickup_sfx");

        gameOver = Resources.Load<AudioClip>("Death_sfx");

        Break = Resources.Load<AudioClip>("ConcreteBreak_sfx");

        getSmall = Resources.Load<AudioClip>("Plop2_sfx");

        getLarge = Resources.Load<AudioClip>("Plop3_sfx");

        Spong = Resources.Load<AudioClip>("Sponge_sfx");



        SFXsource = GetComponent<AudioSource>();

        //currentlanechange = Ensureplayed();
        // StartCoroutine(currentlanechange);


    }

    public static void playSFX(String clip)
    {
        switch (clip)
        {
            case "Jump":
            case "playerJump":

                SFXsource.PlayOneShot(playerJump);
                break;

            case "Smaller":
            case "getSmall":

                SFXsource.PlayOneShot(getSmall);

                break;


            case "Bigger":
            case "getLarge":

                SFXsource.PlayOneShot(getLarge);

                break;

            case "Death":
            case "gameOver":
            case "kill":

                SFXsource.PlayOneShot(gameOver);

                break;

            case "ConcreteBreak":
            case "Break":

                SFXsource.PlayOneShot(Break);
                break;

            case "Pickup":
            case "Slimeball":
                SFXsource.PlayOneShot(Slimeball);
                break;

        }




        //SFXsource.PlayOneShot(clip);
    }


    public static void playbystring(String clip)
    {
        SFXsource.PlayOneShot(Resources.Load<AudioClip>(clip));
    }

    public AudioClip getBreakSFX()
    {
        return Break;
    }

    public void stopSFX()
    {
        SFXsource.Pause();
    }

    public void resumeSFX()
    {
        SFXsource.UnPause();
    }
}