using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {


	public static SoundManager instance;

	private int poolLength;

	public string[] namePools;
	public PoolAudioSources[] pools;

	public Dictionary<string, PoolAudioSources> dicoAudioPool;

	// Use this for initialization
	void Start (){
		instance=this;

		dicoAudioPool=new Dictionary<string, PoolAudioSources>();

		if(namePools.Length==pools.Length){
			for(int i=0;i<pools.Length;i++){
				dicoAudioPool.Add(namePools[i],pools[i]);
			}
		}
	}

	public void PlaySound(string name){
//		sounds[1].
		if(dicoAudioPool.ContainsKey(name))
			dicoAudioPool[name].PlaySound();
	}


}
