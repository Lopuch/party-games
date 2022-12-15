import { Component, OnInit } from '@angular/core';
import {GameService} from "../../../services/game/game.service";

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.scss'],
})
export class PlayerListComponent implements OnInit {

  constructor(
    public gameService: GameService,
  ) { }

  ngOnInit() {}

}
