import { Home } from "./components/Home";
import { Music } from "./components/Music";
import { Game } from "./components/Game";
import { Article } from "./components/Article";
import { Image } from "./components/Image";


const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/music',
    element: <Music />
  },
  {
    path: '/game',
    element: <Game />
  },
  {
    path: '/article',
    element: <Article />
  },
  {
    path: '/image',
    element: <Image />
  }
];

export default AppRoutes;
