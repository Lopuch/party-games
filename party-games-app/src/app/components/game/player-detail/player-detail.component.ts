import {Component, Input, OnInit} from "@angular/core";
import {Player} from "../../../models/player";
import {GameService} from "../../../services/game/game.service";
import {GameStates_Enum} from "../../../models/game";
import {AuthService} from "../../../services/shared/auth.service";

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.scss'],
})
export class PlayerDetailComponent implements OnInit {

  @Input() player: Player;

  constructor(
    public gameService: GameService,
    private auth: AuthService,
  ) { }

  ngOnInit() {}

  isNewPointsVisible(){
    return Number.isInteger(this.getNewPoints());
  }

  getNewPoints(){

    if(this.gameService.game.gameState !== GameStates_Enum.roundEvaluation){
      return undefined;
    }

    return this.gameService.game?.lastResults?.find(x=>x.playerName === this.player.name)?.points;
  }

  isMe() {
    return this.player.name === this.auth.user.name
  }
}
