import React, { useEffect } from 'react';
import { NavMenu } from './NavMenu';
import { useMusicStore } from '../store';

export const Layout = props => {
  const selectdMusic = useMusicStore((state) => state.selectdMusic)

  useEffect(() => {
    console.log(selectdMusic);
    let audio = document.getElementById('bgMusic');
    if (selectdMusic !== '' && audio !== null) {
      audio.pause();
      audio.load();
      audio.play();
    }
  }, [selectdMusic]);

  return (
    <div>
      <NavMenu />
      <div className='grid h-screen'>
        {props.children}
      </div>
      <audio id='bgMusic' preload='auto' autoPlay>
        <source src={selectdMusic} type="audio/mp3" />
      </audio>
    </div>
  );
}
