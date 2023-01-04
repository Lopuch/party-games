import {Component, OnInit} from "@angular/core";
import {AuthService} from "../../../services/shared/auth.service";
import {ActionSheetController, NavController, ToastController} from "@ionic/angular";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.scss"],
})
export class UserProfileComponent implements OnInit {

  constructor(
    public auth: AuthService,
    private actionSheetController: ActionSheetController,
  ) {
  }

  ngOnInit() {
  }

  async onClick() {
    const actionSheet = await this.actionSheetController.create({
      header: "User profile",
      buttons: [{
        text: "Log out",
        icon: "exit-outline",
        handler: () => {
          this.auth.logout();
        }
      },
      ]
    });
    await actionSheet.present();
  }
}
