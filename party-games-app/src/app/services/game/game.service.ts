import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Game} from "../../models/game";
import {environment} from "../../../environments/environment";
import {AuthService} from "../shared/auth.service";

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameId: string;

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
    return await this.httpClient.post(`${environment.apiUrl}game/join`,{gameId, playerId: this.authService.user.id}).toPromise();
  }

  async reloadGame(){
    if(!this.gameId){
      throw new Error("GameService is not initialized");
    }

    this.game = await this.httpClient.get<Game>(`${environment.apiUrl}game/getGame/${this.gameId}`).toPromise();
  }
}
