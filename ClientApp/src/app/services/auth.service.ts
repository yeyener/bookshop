import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthService {

  private apiEndPoint = 'api/auth/';

  constructor(private http: HttpClient) { }

  login(user) {
    return this.http.post(this.apiEndPoint + 'login', user);
  }

  signup(user) {
    return this.http.post(this.apiEndPoint + 'signup', user);
  }

  createHttpHeaderFromJwt() {
    const jwt = localStorage.getItem('jwt');
    const header = new HttpHeaders({
      'Authorization': 'Bearer ' + jwt,
    });
    return header;
  }

}


