import {AfterViewInit, Component, OnDestroy, OnInit} from "@angular/core";
import {GameService} from "../../../services/game/game.service";
import {star} from "ionicons/icons";

@Component({
  selector: "app-timer",
  templateUrl: "./timer.component.html",
  styleUrls: ["./timer.component.scss"],
})
export class TimerComponent implements OnInit, OnDestroy, AfterViewInit {

  interval;

  width = 100;

  constructor(
    public gameService: GameService,
  ) {
  }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.interval = setInterval(() => {
      this.calculate();
    }, 500);
  }

  calculate() {
    const startTime = new Date(this.gameService.game.round.startTime).getTime();
    const endTime = new Date(this.gameService.game.round.endTime).getTime();
    const seconds = endTime - startTime;
    const now = new Date().getTime();
    const secondsFromStart = now - startTime;

    let percentage = secondsFromStart / seconds * 100;
    //console.log("percentage: ", {percentage, secondsFromStart, seconds})

    percentage = Math.min(percentage, 100);

    percentage = 100 - percentage;

    this.width = percentage;
  }

  ngOnDestroy(): void {
    clearInterval(this.interval)
  }

}
