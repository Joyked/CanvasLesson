using UnityEngine;

public class SoundPlayer : Music
{
     private SoundButton _button;

     private void Awake()
     {
          _button = GetComponent<SoundButton>();
          _button.ButtonPressed += Play;
     }

     protected override void Unsubscribe()
     {
          base.Unsubscribe();
          _button.ButtonPressed -= Play;
     }

     private void Play() =>
          AudioSource.Play();
}
