import {Component, Input, OnInit} from "@angular/core";
import {GameStates_Enum} from "../../models/game";
import {GameService} from "../../services/game/game.service";
import {RoundOption} from "../../models/round-option";

@Component({
  selector: "app-game",
  templateUrl: "./game.component.html",
  styleUrls: ["./game.component.scss"],
})
export class GameComponent implements OnInit {

  @Input() gameId: string;

  gameStates = GameStates_Enum;

  interval;

  constructor(
    public gameService: GameService,
  ) {
  }

  async ngOnInit() {
    console.log("gameId: ", this.gameId);

    this.gameService.init(this.gameId);

    await this.gameService.reloadGame();

    this.interval = setInterval(async () => {
      await this.gameService.reloadGame();
    }, 500);
  }

  ngOnDestroy() {
    if (this.interval) {
      clearInterval(this.interval);
    }
  }

  async onStartGameClick() {
    await this.gameService.startGame();
  }

  getGameStateText() {
    switch (this.gameService.game.gameState) {

      case this.gameStates.prepare:
        return "Wait for your friend to join and than pres 'Start the game'";

      case this.gameStates.play:
        return "Select an option";

      case this.gameStates.roundEvaluation:
        return "Prepare for the next round";

      case this.gameStates.finish:
        return "Congrats to the winner"
    }
  }

}
