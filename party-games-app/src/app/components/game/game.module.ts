import {NgModule} from "@angular/core";
import {GameComponent} from "./game.component";
import {IonicModule} from "@ionic/angular";
import {CommonModule} from "@angular/common";
import {PlayerListComponent} from "./player-list/player-list.component";
import {PlayerDetailComponent} from "./player-detail/player-detail.component";
import {PlayerPointsComponent} from "./player-points/player-points.component";
import {OptionComponent} from "./option/option.component";

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
  ],
  exports: [
    GameComponent
  ],
  declarations: [GameComponent, PlayerListComponent, PlayerDetailComponent, PlayerPointsComponent, OptionComponent]
})
export class GameModule {
}
