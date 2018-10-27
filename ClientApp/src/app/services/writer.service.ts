import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WriterService {

  private readonly apiEndPoint = 'api/writers/';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getAll() {
    return this.http.get(this.apiEndPoint + 'getAll', { headers : this.authService.createHttpHeaderFromJwt() });
  }

  getAllNames() {
    return this.http.get(this.apiEndPoint + 'getAllNames');
  }

  getAllNamesAndIds() {
    return this.http.get(this.apiEndPoint + 'getAllNamesAndIds');
  }

  delete(id) {
    return this.http.delete(this.apiEndPoint + id);
  }

  update(writer) {
    return this.http.put(this.apiEndPoint + writer.id , writer);
  }

  create(writer) {
    return this.http.post(this.apiEndPoint + 'create' , writer);
  }

}
