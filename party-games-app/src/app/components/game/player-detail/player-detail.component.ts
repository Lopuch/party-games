import {Component, Input, OnInit} from "@angular/core";
import {Player} from "../../../models/player";

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.scss'],
})
export class PlayerDetailComponent implements OnInit {

  @Input() player: Player;

  constructor() { }

  ngOnInit() {}

}
