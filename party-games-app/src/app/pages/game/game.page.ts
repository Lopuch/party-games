import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {NavController} from "@ionic/angular";
import {GameService} from "../../services/game/game.service";

@Component({
  selector: 'app-game',
  templateUrl: './game.page.html',
  styleUrls: ['./game.page.scss'],
})
export class GamePage implements OnInit {

  gameId: string;

  constructor(
    private route: ActivatedRoute,
    public gameService: GameService,
  ) {

  }

  async ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get("gameId");
    console.log("gameId: ", this.gameId);

    this.gameService.init(this.gameId);

    await this.gameService.reloadGame();
  }

}
