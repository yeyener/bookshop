import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BookInstService {

  private endPointUrl = 'api/bookInstances/';
  constructor(private http: HttpClient) { }

  create(bookInstance) {
    return this.http.post(this.endPointUrl + 'create' , bookInstance);
  }

  edit(bookInstance) {
    return this.http.post(this.endPointUrl + 'edit' , bookInstance);
  }

  delete(biId) {
    return this.http.delete(this.endPointUrl + biId);
  }

  get() {
    return this.http.get(this.endPointUrl);
  }

  getByCustom(queryObject) {
     return this.http.get(this.endPointUrl + 'getByCustom?' + this.toQueryString(queryObject));
  }


  toQueryString(obj): string {
    const parts = [];

    for (const property in obj) {
        if (obj[property] !== null && obj[property] !== undefined) {
          parts.push(encodeURIComponent(property)  + '=' + encodeURIComponent(obj[property]));
        }
    }
    return parts.join('&');
  }
}
