import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {

  // private readonly apiEndpoint = 'api/bookInstPhotos/';

  constructor(private http: HttpClient) { }

  upload(bookInstId, file) {
    const formData = new FormData(); // native js object
    formData.append('file', file); // PhotosController'daki IFormFile'ın parametre adı ile aynı olmalı!
    return this.http.post(`api/bookInstPhotos/${bookInstId}/`, formData);
  }

  getPhotos(bookInstId) {
    return this.http.get(`api/bookInstPhotos/${bookInstId}/`);
  }

}
