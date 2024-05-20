using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlMusica : MonoBehaviour
{
    [SerializeField] private AudioMixer musica;
    [SerializeField] private AudioMixer sonido;
    public void ControldeMusica(float sliderMusica){
        musica.SetFloat("VolumenMusica",Mathf.Log10(sliderMusica)*20);
    }
    public void ControldeSonido(float sliderSonido){
        sonido.SetFloat("VolumenSonido",Mathf.Log10(sliderSonido)*20);
    }
}
