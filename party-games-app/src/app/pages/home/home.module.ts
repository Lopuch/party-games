import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { HomePage } from './home.page';

import { HomePageRoutingModule } from './home-routing.module';
import {GameListModule} from "../../components/game-list/game-list.module";
import {LoginModule} from "../../components/login/login.module";
import {UserModule} from "../../components/user/user.module";


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    GameListModule,
    LoginModule,
    UserModule
  ],
  declarations: [HomePage]
})
export class HomePageModule {}
