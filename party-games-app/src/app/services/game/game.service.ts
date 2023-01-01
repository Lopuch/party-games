import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Game, GameStates_Enum} from "../../models/game";
import {environment} from "../../../environments/environment";
import {AuthService} from "../shared/auth.service";
import {RoundOption} from "../../models/round-option";

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameId: string;

  public selectedOptionIndex: number;

  game: Game;

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
  ) { }

  public init(gameId: string){
    this.gameId = gameId;
  }

  async createGame(name: string): Promise<Game>{
    return await this.httpClient.post<Game>(`${environment.apiUrl}game/create`,{name}).toPromise();
  }

  async joinGame(gameId: string){
    return await this.httpClient.post(`${environment.apiUrl}game/join`,{
      gameId,
      playerId: this.authService.user.id
    }).toPromise();
  }

  async reloadGame(){
    if(!this.gameId){
      throw new Error("GameService is not initialized");
    }

    const prevGameState = this.game?.gameState;

    const res = await this.httpClient.get<Game>(`${environment.apiUrl}game/getGame/${this.gameId}`).toPromise();
    this.assignNewValuesToGame(res);

    if(!prevGameState){
      this.selectedOptionIndex = undefined;
      return;
    }


    if(
      prevGameState === GameStates_Enum.roundEvaluation &&
      this.game.gameState === GameStates_Enum.play){
      this.selectedOptionIndex = undefined;
    }
  }

  async startGame(){
    await this.httpClient.post<void>(`${environment.apiUrl}game/startGame`, {
      gameId: this.gameId,
      playerId: this.authService.user.id
    }).toPromise();
  }

  async selectOption(option: RoundOption){
    if(this.selectedOptionIndex !== undefined){
      return;
    }

    const optionIndex = this.game.round?.options?.indexOf(option);

    const prevSelectedOptionIndex = this.selectedOptionIndex;

    this.selectedOptionIndex = optionIndex;

    try {
      await this.httpClient.post<void>(`${environment.apiUrl}game/selectOption`, {
        gameId: this.gameId,
        playerId: this.authService.user.id,
        optionIndex: optionIndex,
      }).toPromise();
    }
    catch{
      this.selectedOptionIndex = prevSelectedOptionIndex;
    }


  }

  private assignNewValuesToGame(gameRes: Game){
    if(!this.game){
      this.game = gameRes;
      return;
    }

    const gameJson = JSON.stringify(this.game);
    const gameResJson = JSON.stringify(gameRes);

    if(gameJson !== gameResJson){
      this.game = gameRes;
      console.log("Nova hra");
    }
  }

}
