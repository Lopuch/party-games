import { Injectable } from '@angular/core';
import {User} from "../../models/user";
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: User;

  private readonly userLocalStorageKey = environment.appPrefix+"user";


  constructor(
    private httpClient: HttpClient,
  ) {
    this.loadUser();
  }

  isLoggedIn(){
    return !!this.user;
  }

  async login(name: string){
    this.user = await this.httpClient.post<User>(`${environment.apiUrl}player/login`,{name}).toPromise();
    this.saveUser();
  }

  async relogin(){
    this.user = await this.httpClient.post<User>(`${environment.apiUrl}player/relogin`,{
      name: this.user.name,
      id: this.user.id,
    }).toPromise();
    this.saveUser();
  }

  private loadUser(){
    this.user = JSON.parse(localStorage.getItem(this.userLocalStorageKey));
  }

  private saveUser(){
    localStorage.setItem(
      this.userLocalStorageKey,
      JSON.stringify(this.user)
    );
  }

}
