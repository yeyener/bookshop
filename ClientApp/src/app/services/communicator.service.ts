import { BookInstance } from './../pocos/bookInstance';
import { Injectable } from '@angular/core';

@Injectable()
export class CommunicatorService {

  private bookInstanceContainer: BookInstance;

  constructor() { }

  push(bi: BookInstance ) {
    this.bookInstanceContainer = bi;
  }

  pop(): BookInstance {
    return this.bookInstanceContainer;
  }

}
