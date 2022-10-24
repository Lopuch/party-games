import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../services/shared/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  constructor(
    public auth: AuthService,
  ) { }

  ngOnInit() {

  }

  async onLoginClick() {
    await this.auth.login("lopuch");
  }
}
