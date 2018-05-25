import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
newUser: any;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }
  register(firstName: string, lastName: string, email: string, password: string, contact: string, region: string, image: string) {
    this.userService.register(firstName, lastName, email, password, contact, region)
      .subscribe((data) => {
        this.newUser = data;
        // console.log(this.newUser);
        this.router.navigateByUrl('/login');
      });
  }
}
