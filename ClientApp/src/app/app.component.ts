import { Component } from '@angular/core';
import { NavBarService } from './services/nav-bar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  private showNavBar;

  constructor(private navBarService: NavBarService, private router: Router) {
    if (this.router.url === 'frontPage') {
      this.showNavBar = false;
    } else {
      this.showNavBar = true;
    }
  }

  title = 'app';
}
