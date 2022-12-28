import {Round} from "./round";
import {Player} from "./player";
import {Result} from "./result";

export class Game {
  id: string;
  name: string;
  round?: Round;
  players?: Player[];
  gameState: GameStates_Enum;
  //results: Result[];
  lastResults: Result[];
}

export enum GameStates_Enum {
  prepare,
  play,
  roundEvaluation,
  finish,
}
