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

  constructor(private bookInstService: BookInstService, private errHandler: BookErrorHandler) { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    this.bookInstService.getByCustom('').subscribe(
      a => {this.instances = <BookInstance[]>a;  this.booksLoaded = Promise.resolve(true); },
      err => this.errHandler.handleError(err));
  }

}
