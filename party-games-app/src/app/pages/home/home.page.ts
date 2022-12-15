import {AfterViewInit, Component, OnInit} from "@angular/core";
import {AuthService} from "../../services/shared/auth.service";
import {GameListService} from "../../services/game/game-list.service";
import {ViewDidEnter, ViewDidLeave} from "@ionic/angular";

@Component({
  selector: "app-home",
  templateUrl: "home.page.html",
  styleUrls: ["home.page.scss"],
})
export class HomePage implements AfterViewInit, ViewDidEnter, ViewDidLeave {

  interval: any;

  constructor(
    public auth: AuthService,
    private gameListService: GameListService,
  ) {
  }

  async ngAfterViewInit() {
  }

  async ionViewDidEnter() {
    if (this.auth.isLoggedIn()) {
      await this.auth.relogin();
    }


    await this.gameListService.reloadGames();

    this.interval = setInterval(async() => {
      await this.gameListService.reloadGames();
    }, 5000);
  }

  ionViewDidLeave() {
    clearInterval(this.interval);
  }

}
