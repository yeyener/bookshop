import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { BookErrorHandler } from '../../handlers/bookErrorHandler';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  user: any = {};

  constructor(private authService: AuthService, private errHandler: BookErrorHandler) { }

  ngOnInit() {
  }


  signup() {
    this.authService.signup(this.user).subscribe(
      res => {
         const t = (<any>res).token ;
         localStorage.setItem('jwt', t);
         console.log(t);
      } ,
      err => this.errHandler.handleError(err));
  }

}
