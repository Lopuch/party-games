import {Component, OnDestroy, OnInit} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {GameService} from "../../services/game/game.service";
import {GameStates_Enum} from "../../models/game";

@Component({
  selector: 'app-game',
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

    await this.gameService.reloadGame();

    this.interval = setInterval(async () => {
      await this.gameService.reloadGame();
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
}
