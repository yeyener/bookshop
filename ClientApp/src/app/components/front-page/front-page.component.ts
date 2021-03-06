import { CommunicatorService } from './../../services/communicator.service';
import { JsonTsConverterService } from '../../json-ts-converter.service';
import { BookdefService } from './../../services/bookdef.service';
import { AutoCompleteTextComponent } from './../auto-complete-text/auto-complete-text.component';
import { AuthService } from './../../services/auth.service';
import { Router } from '@angular/router';
import { FrontPageService } from './../../services/front-page.service';
import { BookErrorHandler } from './../../handlers/bookErrorHandler';
import { BookInstService } from './../../services/book-inst.service';
import { BookInstance } from './../../pocos/bookInstance';
import { Component, OnInit } from '@angular/core';
import {JsonConvert, OperationMode, ValueCheckingMode} from 'json2typescript';


@Component({
  selector: 'app-front-page',
  templateUrl: './front-page.component.html',
  styleUrls: ['./front-page.component.css']
})
export class FrontPageComponent implements OnInit {

  private instances: BookInstance[];
  private booksLoaded: Promise<boolean>;

  private writersAndBooksLoaded: Promise<boolean>;

  private cartItems: any = [];

  private writersAndBooks: any = [];

  private userLoggedIn = false;

  private selectedBookOrWriter: any;

  constructor(private bookInstService: BookInstService, private errHandler: BookErrorHandler, private fpService: FrontPageService,
     private router: Router, private authService: AuthService, private bookDefService: BookdefService,
     private jsonTsConverter: JsonTsConverterService, private communicatorService: CommunicatorService) {
  }

  ngOnInit() {
    this.userLoggedIn = !this.authService.isExpired();
    this.getBooks();
    this.getSearchBarData();
  }

  getSearchBarData() {
    this.writersAndBooks = this.bookDefService.getNames().subscribe(
      a => {this.writersAndBooks = a;  this.writersAndBooksLoaded = Promise.resolve(true); },
      err => this.errHandler.handleError(err)
      );

  }

  getBooks() {
    this.bookInstService.get().subscribe(
      a => { this.instances = <BookInstance[]>a; /* convert kullanılacak TODO */  this.booksLoaded = Promise.resolve(true); },
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
    window.location.reload();
  }

  onFrontPageSearch() {

  }

  goToPublicBookInst(book: BookInstance) {
    this.communicatorService.push<BookInstance>(book);
    this.router.navigate(['/public-book-inst']);
  }

}
