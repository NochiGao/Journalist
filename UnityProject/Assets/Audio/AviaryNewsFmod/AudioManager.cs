using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance music;
    private FMOD.Studio.ParameterInstance paramOpo;
    private FMOD.Studio.ParameterInstance paramOfi;
    private FMOD.Studio.ParameterInstance paramNews;

    private void Start()
    {
		MenuStart ();
    }

    public void MenuStart()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu Music");
		music.start();
    }

    public void GameStart()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        music.release();
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Ingame Music");
        music.getParameter("Opposition", out paramOpo);
        music.getParameter("Officialism", out paramOfi);
        music.getParameter("Radio News", out paramNews);
    }

    public void MusicInGameStart()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        music.start();
    }

    public void SetOfficialism()
    {
        paramOfi.setValue(1f);
        paramOpo.setValue(0f);
        paramNews.setValue(0f);
    }

    public void SetOpposition()
    {
        paramOfi.setValue(0f);
        paramOpo.setValue(1f);
        paramNews.setValue(0f);
    }

    public void SetRadioNews()
    {
        paramOfi.setValue(0f);
        paramOpo.setValue(0f);
        paramNews.setValue(1f);
    }

    public void GameExit()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        music.release();
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu Music");
        music.start();
    }
}
