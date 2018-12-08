import { NavBarService } from './../services/nav-bar.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

// Mevcut Metot ve propertylere elleme!
// İlk haline geri çevirdim. collapse olmadığı zaman navigation'da sayfaları iki kere yüklemeye, her comp'u
// sıfırdan yüklemye çalışıyor. Patlıyor ve aşırı yavaşlıyor.
export class NavMenuComponent {
  isExpanded = false;
   collapse() {
    this.isExpanded = false;
  }
   toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
