import {Component, OnInit} from "@angular/core";
import {GameService} from "../../services/game/game.service";
import {NavController} from "@ionic/angular";
import {GameListService} from "../../services/game/game-list.service";

@Component({
  selector: "app-game-list",
  templateUrl: "./game-list.component.html",
  styleUrls: ["./game-list.component.scss"],
})
export class GameListComponent implements OnInit {

  constructor(
    public gameService: GameService,
    public gameListService: GameListService,
    private navController: NavController,
  ) {
  }

  async ngOnInit() {
    await this.gameListService.reloadGames();
  }

  async onCreateGameClick() {
    const createdGame = await this.gameService.createGame("test game 1");
    console.log("Created game: ", createdGame);

    await this.gameService.joinGame(createdGame.id);

    this.navController.navigateForward(["game", createdGame.id]).then();
  }
}
