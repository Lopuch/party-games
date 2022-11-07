import {Component, Input, OnInit} from "@angular/core";
import {Game} from "../../../models/game";
import {GameService} from "../../../services/game/game.service";
import {NavController} from "@ionic/angular";

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss'],
})
export class GameCardComponent implements OnInit {

  @Input() game: Game;

  constructor(
    private gameService: GameService,
    private navController: NavController,
  ) { }

  ngOnInit() {}

  async onJoinGameClick() {
    await this.gameService.joinGame(this.game.id);

    this.navController.navigateForward(["game", this.game.id]).then();
  }
}
