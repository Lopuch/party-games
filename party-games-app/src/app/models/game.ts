import {Round} from "./round";
import {Player} from "./player";

export class Game {
  id: string;
  name: string;
  round?: Round;
  players?: Player[];
  gameState: GameStates_Enum;
}

export enum GameStates_Enum {
  prepare,
  play,
  roundEvaluation,
  finish,
}
