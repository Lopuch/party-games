import {NgModule} from "@angular/core";
import {GameListComponent} from "./game-list.component";
import {GameCardComponent} from "./game-card/game-card.component";

@NgModule({
  exports: [
    GameListComponent
  ],
  declarations: [
    GameListComponent,
    GameCardComponent,
  ]
})
export class GameListModule {
}
