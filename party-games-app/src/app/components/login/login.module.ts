import {NgModule} from "@angular/core";
import {LoginComponent} from "./login.component";
import {IonicModule} from "@ionic/angular";
import {NgIf} from "@angular/common";

@NgModule({
  imports: [
    IonicModule,
    NgIf
  ],
  exports: [
    LoginComponent
  ],
  declarations: [LoginComponent]
})
export class LoginModule {
}
