import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {UserService} from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService]
})
export class LoginComponent implements OnInit {


  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }
  loginUser(email: string, password: string) {
    this.userService.login(email, password)
      .subscribe((data: any) => {
        if (data != null) {
          console.log(data);
          sessionStorage.setItem('currentUserEmail', email);
          console.log(sessionStorage.getItem('currentUserEmail'));
          this.router.navigateByUrl('/playground');
        }
      });
  }
}
