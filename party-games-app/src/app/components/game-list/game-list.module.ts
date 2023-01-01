import {NgModule} from "@angular/core";
import {GameListComponent} from "./game-list.component";
import {GameCardComponent} from "./game-card/game-card.component";
import {IonicModule} from "@ionic/angular";
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";

@NgModule({
  exports: [
    GameListComponent
  ],
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
  ],
  declarations: [
    GameListComponent,
    GameCardComponent,
  ]
})
export class GameListModule {
}
