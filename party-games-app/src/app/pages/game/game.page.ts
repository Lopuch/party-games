import {Component, OnDestroy, OnInit} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {GameService} from "../../services/game/game.service";
import {GameStates_Enum} from "../../models/game";
import {RoundOption} from "../../models/round-option";

@Component({
  selector: 'app-game-page',
  templateUrl: './game.page.html',
  styleUrls: ['./game.page.scss'],
})
export class GamePage implements OnInit, OnDestroy {

  gameStates = GameStates_Enum;

  gameId: string;

  interval;

  constructor(
    private route: ActivatedRoute,
    public gameService: GameService,
  ) {

  }

  async ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get("gameId");
    console.log("gameId: ", this.gameId);

    this.gameService.init(this.gameId);

    //await this.gameService.reloadGame();

    this.interval = setInterval(async () => {
      //await this.gameService.reloadGame();
    }, 1000);
  }

  ngOnDestroy() {
    if(this.interval){
      clearInterval(this.interval);
    }
  }

  async onStartGameClick() {
    await this.gameService.startGame();
  }

  async onOptionClick(option: RoundOption) {
    await this.gameService.selectOption(option);
  }

  getGameStateText() {
    switch (this.gameService.game.gameState)
    {

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
