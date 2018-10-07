import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BookdefService {

  private readonly apiEndPoint = "api/bookDefinitions/"
  constructor(private http : HttpClient) { }

  getWritersBookDefs(writerId){
    return this.http.get(this.apiEndPoint + "getWritersBookDefs?writerId=" + writerId);
  }

  updateBookDef(bookDef){
    return this.http.put(this.apiEndPoint + bookDef.id , bookDef);
  }

  createBookDef(bookDef){
    return this.http.post(this.apiEndPoint + "create/" , bookDef);
  }

  deleteBookDef(bookDef){
    return this.http.delete(this.apiEndPoint+ bookDef.id );    
  }

}