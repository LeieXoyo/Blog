import { useEffect, useState } from "react";

export const Game = (props) => {
  const [games, setGames] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getAllGameData();
  }, []);

  async function getAllGameData() {
    const response = await fetch("api/Game");
    const data = await response.json();
    setGames(data);
    setLoading(false);
  }

  function StartGame(e, id) {
    const element = window.document.getElementById(`game_modal_${id}`);
    if (element !== null) {
      element.showModal();
    }
  }

  function CloseGame(e, id) {
    const element = window.document.getElementById(`game_modal_${id}`);
    if (element !== null && e.target.tagName !== "IFRAME") {
      element.close();
    }
  }

  return (
    <>
      {loading ? (
        <div className="grid h-screen">
          <span className="loading loading-ring loading-lg self-center justify-self-center"></span>
        </div>
      ) : (
        <div className="grid grid-flow-row-dense grid-cols-2 gap-4 lg:grid-cols-4">
          {games.map((g) => {
            return (
              <div
                key={g.id}
                className="card card-compact bg-base-100 shadow-xl"
              >
                <figure>
                  <img src={g.imgUrl} alt="Games" />
                </figure>
                <div className="card-body">
                  <h2 className="card-title">{g.name}</h2>
                  <div className="card-actions justify-end">
                    <button
                      className="btn btn-primary"
                      onClick={(e) => StartGame(e, g.id)}
                    >
                      启动
                    </button>
                  </div>
                </div>
                <dialog
                  id={`game_modal_${g.id}`}
                  className="modal backdrop-blur-sm"
                  onClick={(e) => CloseGame(e, g.id)}
                >
                  <iframe
                    title={g.name}
                    src={g.htmlUrl}
                    className="w-5/6 h-5/6"
                  ></iframe>
                </dialog>
              </div>
            );
          })}
        </div>
      )}
    </>
  );
};
