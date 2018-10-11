import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MiscService {

  private apiEndPoint = 'api/misc/';

  constructor(private http: HttpClient) { }

  getTranslators() {
    return this.http.get(this.apiEndPoint + 'getTranslators');
  }

  getLanguages() {
    return this.http.get(this.apiEndPoint + 'getLanguages');
  }

  getPublishers() {
    return this.http.get(this.apiEndPoint + 'getPublishers');
  }
}
