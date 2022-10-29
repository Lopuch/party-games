import {NgModule} from "@angular/core";
import {UserProfileComponent} from "./user-profile/user-profile.component";
import {NgIf} from "@angular/common";

@NgModule({
  imports: [
    NgIf
  ],
  exports: [
    UserProfileComponent
  ],
  declarations: [UserProfileComponent]
})
export class UserModule {
}
