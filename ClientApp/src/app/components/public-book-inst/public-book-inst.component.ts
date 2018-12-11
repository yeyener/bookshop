import { Component, OnInit } from '@angular/core';
import { BookInstance } from '../../pocos/bookInstance';
import { CommunicatorService } from '../../services/communicator.service';

@Component({
  selector: 'app-public-book-inst',
  templateUrl: './public-book-inst.component.html',
  styleUrls: ['./public-book-inst.component.css']
})
export class PublicBookInstComponent implements OnInit {

  private book: BookInstance;
  private bookLoaded: Promise<boolean>;

  constructor(private communicator: CommunicatorService) { }

  ngOnInit() {
    this.getBook();
  }

  getBook() {
    this.book = this.communicator.pop<BookInstance>();
    this.bookLoaded = Promise.resolve(true);
  }

}
