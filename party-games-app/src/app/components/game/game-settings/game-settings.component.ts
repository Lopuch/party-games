import { Component, OnInit } from '@angular/core';
import {GameSettingsService} from "../../../services/game-settings/game-settings.service";
import {GameService} from "../../../services/game/game.service";

@Component({
  selector: 'app-game-settings',
  templateUrl: './game-settings.component.html',
  styleUrls: ['./game-settings.component.scss'],
})
export class GameSettingsComponent implements OnInit {

  constructor(
    public gameSettingsService: GameSettingsService,
    public gameService: GameService,
  ) { }

  ngOnInit() {}

  onCloseClick() {
    this.gameSettingsService.isVisible = false;
  }

  isSolveEvaluationEnabled() {
    return !!this.gameService.game?.allowedGameTypes.includes("solveEvaluation");
  }

  isMostImagesEnabled() {
    return !!this.gameService.game?.allowedGameTypes.includes("mostImages");
  }

  async onSolveEvaluationChanged() {
    if(!this.isSolveEvaluationEnabled()){
      await this.gameService.enableGameType("solveEvaluation");
    }else{
      await this.gameService.disableGameType("solveEvaluation");
    }
  }

  async onMostImagesChanged() {
    if(!this.isMostImagesEnabled()){
      await this.gameService.enableGameType("mostImages");
    }else{
      await this.gameService.disableGameType("mostImages");
    }
  }
}
