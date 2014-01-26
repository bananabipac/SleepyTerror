using UnityEngine;
using System.Collections;

[System.Serializable]
public class PoolAudioSources : MonoBehaviour{
	public string name;
	public AudioSource[] audios;
	public int index;

	public PoolAudioSources(string  name, int poolLength, AudioClip clip){
		audios=new AudioSource[poolLength];
	}

	public void PlaySound(){
		audios[index].Play();
		index=(index+1)%audios.Length;
	}
}
