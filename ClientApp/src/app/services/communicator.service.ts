import { BookInstance } from './../pocos/bookInstance';
import { Injectable } from '@angular/core';

@Injectable()
export class CommunicatorService {

  private container: any;

  constructor() { }

  push<T>(bi: T ) {
    this.container = bi;
  }

  pop<T>(): T {
    return this.container;
  }

}
