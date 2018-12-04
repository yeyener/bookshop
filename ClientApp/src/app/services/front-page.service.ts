import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class FrontPageService {

  private apiEndPoint = 'api/frontPage/';

  constructor(private http: HttpClient) { }

  addBookToCart(bookId) {
    return this.http.post(this.apiEndPoint + 'addToCart' , bookId);
  }

}
