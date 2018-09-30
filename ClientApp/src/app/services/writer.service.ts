import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WriterService {

  private readonly apiEndPoint = "api/writers"

  constructor(private http : HttpClient) { }

  getAll(){
    return this.http.get(this.apiEndPoint + "/getAll");

  }

}
