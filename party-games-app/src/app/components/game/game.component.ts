import {Component, Input, OnInit} from "@angular/core";
import {GameStates_Enum} from "../../models/game";
import {GameService} from "../../services/game/game.service";
import {RoundOption} from "../../models/round-option";
import {NavController} from "@ionic/angular";
import {GameSettingsService} from "../../services/game-settings/game-settings.service";

@Component({
  selector: "app-game",
  templateUrl: "./game.component.html",
  styleUrls: ["./game.component.scss"],
})
export class GameComponent implements OnInit {

  @Input() gameId: string;

  gameStates = GameStates_Enum;

  interval;

  isSettingsVisible = false;

  constructor(
    public gameService: GameService,
    private navController: NavController,
    private gameSettingsService: GameSettingsService,
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
        return "Wait for your friends to join and then pres 'Start the game'";

      case this.gameStates.play:
        return "Play";

      case this.gameStates.roundEvaluation:
        return "Prepare";

      case this.gameStates.finish:
        return "Congrats to the winner"
    }
  }

  onHomeClick() {
    this.navController.navigateRoot("/").then();
  }

  onSettingsClick() {
    this.gameSettingsService.isVisible = !this.gameSettingsService.isVisible;
  }
}
