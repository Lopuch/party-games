import {Component, Input, OnInit} from "@angular/core";
import {GameService} from "../../../services/game/game.service";
import {RoundOption} from "../../../models/round-option";
import {GameStates_Enum} from "../../../models/game";

@Component({
  selector: 'app-option',
  templateUrl: './option.component.html',
  styleUrls: ['./option.component.scss'],
})
export class OptionComponent implements OnInit {

  @Input() option: RoundOption;

  constructor(
    public gameService: GameService,
  ) { }

  ngOnInit() {}

  onClick(){
    console.log("Click");

    if(!this.isClickable()){
      return;
    }

    this.gameService.selectOption(this.option).then();
  }

  isClickable(){
    if(this.gameService.game.gameState !== GameStates_Enum.play){
      return false;
    }

    if(this.gameService.selectedOptionIndex !== undefined){
      return false;
    }

    return true;
  }

  isCorrect(){
    return this.option.publicIsCorrect;
  }

  isWrong(){
    if(this.gameService.game.gameState !== GameStates_Enum.roundEvaluation){
      return false;
    }

    if(this.getOptionIndex() !== this.gameService.selectedOptionIndex){
      return false;
    }

    return !this.option.publicIsCorrect;
  }

  isSelected(){
    return this.gameService.selectedOptionIndex === this.getOptionIndex();
  }

  private getOptionIndex(){
    return this.gameService.game.round.options.indexOf(this.option);
  }

}
