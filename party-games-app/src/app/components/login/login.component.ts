import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../services/shared/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  inputName: string;

  constructor(
    public auth: AuthService,
  ) {
    this.generateName();
  }

  ngOnInit() {

  }

  private generateName(){


    this.inputName = "SuperPlayer"+ Math.ceil(Math.random()*100000);
  }

  async onLoginClick() {
    await this.auth.login("lopuch");
  }
}
