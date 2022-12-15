import {Component, Input, OnInit} from "@angular/core";

@Component({
  selector: 'app-player-points',
  templateUrl: './player-points.component.html',
  styleUrls: ['./player-points.component.scss'],
})
export class PlayerPointsComponent implements OnInit {

  @Input() points: number;

  constructor() { }

  ngOnInit() {}

}
