import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {UserService} from '../user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  providers: [UserService]
})
export class NavbarComponent implements OnInit {
followingCount: number;
  constructor(private userService: UserService, private router: Router) {
    this.followingCount = +localStorage.getItem('followingCount');
    this.followersCount = +localStorage.getItem('followersCount');
  }
followersCount: number;
  ngOnInit() {
  }
  logout() {
    this.userService.logout()
      .subscribe((data) => {
        sessionStorage.clear();
        this.router.navigateByUrl('/login');
      });
  }

}
