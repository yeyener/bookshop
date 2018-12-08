import { JwtHelper } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthService {

  private apiEndPoint = 'api/auth/';

  private jwtKey = 'jwt';

  constructor(private http: HttpClient, private jwtHelper: JwtHelper) { }

  login(user) {
    return this.http.post(this.apiEndPoint + 'login', user);
  }

  signup(user) {
    return this.http.post(this.apiEndPoint + 'signup', user);
  }
  logout() {
    localStorage.removeItem(this.jwtKey);
  }

  createHttpHeaderFromJwt() {
    const jwt = this.getToken();
    const header = new HttpHeaders({
      'Authorization': 'Bearer ' + jwt,
    });
    return header;
  }

  isExpired() {
    if (this.getToken() === null ) {
      return true;
    }
    return this.jwtHelper.isTokenExpired(this.getToken());
  }

  private getToken() {
    const token = localStorage.getItem(this.jwtKey);
    if (token === null || token === void 0) {
      return null;
    }
    return localStorage.getItem(this.jwtKey);
  }

}
