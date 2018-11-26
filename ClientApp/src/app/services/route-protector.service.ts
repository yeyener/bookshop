import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRoute } from '@angular/router';

@Injectable()
export class RouteProtectorService implements CanActivate {

  constructor( private router: Router) {
  }

  canActivate() {

    // this.router.navigate(['login']);
    return true;

    //   const token = localStorage.getItem('jwt');
    //   if (token && !this.jwtHelper.isTokenExpired(token)) {
    //     return true;
    //   }
    //   this.router.navigate(['login']);
    //   return false;
    // }
  }
}
