import {NgModule} from "@angular/core";
import {LoginComponent} from "./login.component";
import {IonicModule} from "@ionic/angular";
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";

@NgModule({
  imports: [
    IonicModule,
    NgIf,
    FormsModule
  ],
  exports: [
    LoginComponent
  ],
  declarations: [LoginComponent]
})
export class LoginModule {
}
