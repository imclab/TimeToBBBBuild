﻿using UnityEngine;
using System.Collections;

public class SoundOnSpecificTick : ISoundOnTick
{
    public AudioClip clip;
    public int playOnTick;
    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        int tick = (int)args[0];
        if ( tick == playOnTick ) {
            Debug.Log( string.Format( "Specific Tick {0}!", tick ) );
            audio.PlayOneShot( clip );
        }
    }
}