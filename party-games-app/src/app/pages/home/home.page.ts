import {AfterViewInit, Component, OnInit} from "@angular/core";
import {AuthService} from "../../services/shared/auth.service";

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements AfterViewInit{

  constructor(
    public auth: AuthService,
  ) {}

  async ngAfterViewInit() {
    if(this.auth.isLoggedIn()){
      await this.auth.relogin();
    }
  }

}
