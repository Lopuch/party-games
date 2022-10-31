import {NgModule} from "@angular/core";
import {GameListComponent} from "./game-list.component";
import {GameCardComponent} from "./game-card/game-card.component";
import {IonicModule} from "@ionic/angular";

@NgModule({
  exports: [
    GameListComponent
  ],
  imports: [
    IonicModule
  ],
  declarations: [
    GameListComponent,
    GameCardComponent,
  ]
})
export class GameListModule {
}
