import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isCollapsed = true;


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    alert('a');
    this.isExpanded = !this.isExpanded;
  }
}
