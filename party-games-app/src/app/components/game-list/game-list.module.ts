import {NgModule} from "@angular/core";
import {GameListComponent} from "./game-list.component";
import {GameCardComponent} from "./game-card/game-card.component";
import {IonicModule} from "@ionic/angular";
import {CommonModule} from "@angular/common";

@NgModule({
  exports: [
    GameListComponent
  ],
  imports: [
    IonicModule,
    CommonModule,
  ],
  declarations: [
    GameListComponent,
    GameCardComponent,
  ]
})
export class GameListModule {
}
