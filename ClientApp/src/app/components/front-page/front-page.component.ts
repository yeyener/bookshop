import { AuthService } from './../../services/auth.service';
import { Router } from '@angular/router';
import { FrontPageService } from './../../services/front-page.service';
import { BookErrorHandler } from './../../handlers/bookErrorHandler';
import { BookInstService } from './../../services/book-inst.service';
import { BookInstance } from './../../pocos/bookInstance';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-front-page',
  templateUrl: './front-page.component.html',
  styleUrls: ['./front-page.component.css']
})
export class FrontPageComponent implements OnInit {

  private instances: BookInstance[];
  private booksLoaded: Promise<boolean>;

  private cartItems: any = [];

  private userLoggedIn = false;

  constructor(private bookInstService: BookInstService, private errHandler: BookErrorHandler, private fpService: FrontPageService,
     private router: Router, private authService: AuthService) {
  }

  ngOnInit() {
    this.userLoggedIn = !this.authService.isExpired();
    this.getBooks();
  }

  getBooks() {
    this.bookInstService.get().subscribe(
      a => {this.instances = <BookInstance[]>a;  this.booksLoaded = Promise.resolve(true); },
      err => this.errHandler.handleError(err));
  }

  addBookToCart(bookId) {
    this.fpService.addBookToCart(bookId).subscribe(
      a => { alert('Added to cart : ' + a); this.cartItems = a; },
      err => this.errHandler.handleError(err)
    );
  }

  goToCart() {
    alert('Not impelemented yet');
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  logout() {
    this.authService.logout();
  }

}
