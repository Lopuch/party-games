import { Injectable } from '@angular/core';
import {Game} from "../../models/game";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class GameListService {

  games: Game[];

  constructor(
    private httpClient: HttpClient,
  ) { }

  async reloadGames(){
    this.games = await this.httpClient.get<Game[]>(`${environment.apiUrl}game/getGames`).toPromise();
  }
}
