import { Injectable } from '@angular/core';

@Injectable()
export class NavBarService {

  showTheNavigationBar = false;

  constructor() {
    this.showTheNavigationBar = false;
   }

   hide() {
    this.showTheNavigationBar = false;
   }

   show() {
    this.showTheNavigationBar = true;
   }

   decideAcoordingToRoute() {

   }

}
