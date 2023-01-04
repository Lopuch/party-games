import {NgModule} from "@angular/core";
import {GameComponent} from "./game.component";
import {IonicModule} from "@ionic/angular";
import {CommonModule} from "@angular/common";
import {PlayerListComponent} from "./player-list/player-list.component";
import {PlayerDetailComponent} from "./player-detail/player-detail.component";
import {PlayerPointsComponent} from "./player-points/player-points.component";
import {OptionComponent} from "./option/option.component";
import {TimerComponent} from "./timer/timer.component";
import {GameSettingsComponent} from "./game-settings/game-settings.component";
import {FormsModule} from "@angular/forms";

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
  ],
  exports: [
    GameComponent
  ],
  declarations: [GameComponent, PlayerListComponent, PlayerDetailComponent, PlayerPointsComponent, OptionComponent, TimerComponent,
    GameSettingsComponent,
  ]
})
export class GameModule {
}
