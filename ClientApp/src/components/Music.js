import { useEffect, useState } from "react"
import { useMusicStore } from '../store.js'

export const Music = props => {
    const [musics, setMusics] = useState([]);
    const [loading, setLoading] = useState(true);

    const selectdMusic = useMusicStore((state) => state.selectdMusic)
    const selectMusic = useMusicStore((state) => state.selectMusic)

    useEffect(() => {
        getAllMusicData();
    }, [selectdMusic]);

    async function getAllMusicData() {
        const response = await fetch('api/Music');
        const data = await response.json();
        setMusics(data);
        setLoading(false);
    };

    function playMusic(fileUrl) {
        selectMusic(fileUrl);
        let audio = document.getElementById('bgMusic');
        if (selectdMusic !== '' && audio !== null) {
            audio.play();
        }
        const musicToggler = document.getElementById('playMusic');
        musicToggler.checked = false;
    }

    return (
        <>
            {
                loading ? <span className="loading loading-ring loading-lg self-center justify-self-center"></span> :
                    <div className="grid grid-flow-row-dense grid-cols-2 gap-4 lg:grid-cols-4">
                        {
                            musics.map(m => {
                                return (
                                    <div key={m.id} className="card card-compact bg-base-100 shadow-xl">
                                        <figure><img src={m.coverUrl} alt="Games" /></figure>
                                        <div className="card-body">
                                            <h2 className="card-title">{m.name}</h2>
                                            <p>{m.author}</p>
                                            <div className="card-actions justify-end">
                                                <button className="btn btn-primary" onClick={(e) => playMusic(m.fileUrl)}>播放</button>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })
                        }
                    </div>
            }
        </>
    );
}