using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

}
