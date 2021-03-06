import { Router } from '@angular/router';
import { AuthService } from './../../services/auth.service';
import { MiscService } from './../../services/misc.service';
import { Component, OnInit, ErrorHandler } from '@angular/core';
import { BookErrorHandler } from '../../handlers/bookErrorHandler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: any = {};

  constructor(private authService: AuthService, private errHandler: BookErrorHandler, private router: Router) { }

  ngOnInit() {
  }


  login() {
    this.authService.login(this.user).subscribe(
      res => {
         const t = (<any>res).token ;
         localStorage.setItem('jwt', t);
         this.router.navigate(['/writer-form']);
         console.log(t);
      } ,
      err => this.errHandler.handleError(err));
  }

  navitageToSignUp() {
    this.router.navigate(['/signup']);
  }

}
